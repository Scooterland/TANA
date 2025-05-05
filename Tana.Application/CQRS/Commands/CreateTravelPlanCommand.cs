using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Application.CQRS.Commands
{
    public class CreateTravelPlanCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public List<Guid> TripIds { get; set; }
    }
}
