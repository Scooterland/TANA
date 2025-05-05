using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Application.CQRS.Commands
{
    public record CreateStandardTripCommand(string Title, string Destination, DateTime StartDate, DateTime EndDate);
}
