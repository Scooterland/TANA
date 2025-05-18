using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
	public class Tur :IEntity
	{
		public int Id { get; set; }
		[Timestamp]
		public byte[] Version { get; set; }

		public string Navn { get; set; }
		public int Pris {  get; set; }
		public int Dage { get; set; }
		public string Description { get; set; }

	}
}
