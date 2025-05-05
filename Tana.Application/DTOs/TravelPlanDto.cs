using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Application.DTOs
{
    public class TravelPlanDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<TripDto> Trips { get; set; } = new();
    }
}
