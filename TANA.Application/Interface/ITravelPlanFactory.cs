using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Application.Interface
{
    public interface ITravelPlanFactory
    {
        Rejse CreateSpecializedPlan(string navn, IEnumerable<Tur> baseTure);
    }
}
