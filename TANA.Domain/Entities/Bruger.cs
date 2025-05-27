using System.ComponentModel.DataAnnotations;

namespace TANA.Domain.Entities
{
    public class Bruger : IEntity
    {
        public int Id { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
        public string Navn { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rolle { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
