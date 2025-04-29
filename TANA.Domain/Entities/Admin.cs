using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
	public class Admin : IEntity
	{
		public int Id { get; set; }
		[Timestamp]
		public byte[] Version { get; set; }

		private string Email { get; set; }
		private string Adgangskode {  get; set; }
	}
}
