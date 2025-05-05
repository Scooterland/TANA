using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
    public class Trip
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Destination { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Trip(string title, string destination, DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            Destination = destination;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
