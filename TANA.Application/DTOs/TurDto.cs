using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Application.DTOs
{
    public class TurDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public int Dage { get; set; }
    }
}
