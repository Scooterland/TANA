using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Application.DTOs
{
    public class RejseplanModel
    {
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Destination { get; set; }
        public string Afrejse { get; set; }
        public string Hjemrejse { get; set; }
        public string Flyselskab { get; set; }
    }
}
