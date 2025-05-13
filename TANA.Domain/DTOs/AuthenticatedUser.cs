using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.DTOs
{
    public class AuthenticatedUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Rolle { get; set; } = string.Empty;
    }
}
