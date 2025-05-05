using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.CQRS.Commands;
using TANA.Domain.Entities;
using TANA.Application.CQRS.Queries;
using TANA.Domain.Repositories;
using TANA.Application.Interfaces;
using MediatR;

namespace TANA.Application.CQRS.Handler
{
    public class CreateTravelPlanHandler : IRequestHandler<CreateTravelPlanCommand, Guid>
    {
        private readonly ITripRepository _tripRepo;
        private readonly ITravelPlanRepository _planRepo;

        public CreateTravelPlanHandler(ITripRepository tripRepo, ITravelPlanRepository planRepo)
        {
            _tripRepo = tripRepo;
            _planRepo = planRepo;
        }

        public async Task<Guid> Handle(CreateTravelPlanCommand request, CancellationToken cancellationToken)
        {
            // Hent trips baseret på TripIds i request
            var trips = await _tripRepo.GetByIdAsync(request.TripIds); // GetByIdAsync skal kunne håndtere en liste af IDs

            if (trips == null || !trips.Any()) // Hvis ingen ture findes, kan vi returnere en fejl eller en default værdi
            {
                throw new Exception("No trips found for the provided IDs");
            }

            var plan = new TravelPlan(request.Name);

            foreach (var trip in trips)
            {
                plan.AddTrip(trip);
            }

            await _planRepo.AddAsync(plan);

            return plan.Id; // Returner ID for den oprettede rejseplan
        }
    }
}
