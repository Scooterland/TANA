using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
    public class TravelPlan
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Trip> Trips { get; private set; } = new();

        public TravelPlan(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void AddTrip(Trip trip) => Trips.Add(trip);
    }
}
