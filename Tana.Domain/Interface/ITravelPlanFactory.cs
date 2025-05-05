using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface ITravelPlanFactory
    {
        TravelPlan CreateSpecializedPlan(string name, IEnumerable<Trip> baseTrips);
    }
}
