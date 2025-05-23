namespace TANA.Domain.Entities
{
    public class AuthenticatedUser
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Rolle { get; set; } = string.Empty;
    }
}
