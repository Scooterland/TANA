using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
	public class Faktura : IEntity
	{
		public int Id { get; set; }
		[Timestamp]
		public byte[] Version { get; set; }

		public DateTime Dato { get; set; }
		public double Pris { get; set; }
		
		public int RejseId {  get; set; }
		public Rejse Rejse { get; set; }

	}
}
