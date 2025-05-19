using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
    public class Rejse : IEntity
    {
        public int Id { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
        public string Navn { get; set; }
        public List<RejseTur> RejseTurer { get; set; } = new List<RejseTur>();
        [Required]
        public DateOnly? StartsDato { get; set; }
        [Required]
        public DateOnly? SlutsDato { get; set; }
        public int Dage { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Pris skal være større end 0.")]
        public double Pris { get; set; }
        public string? Kommentar { get; set; }

        [Required] public int? KundeId { get; set; }
        public Kunde? Kunde { get; set; }
    }
}
