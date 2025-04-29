using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
	public class RejseTur :IEntity
	{
		public int Id { get; set; }
		[Timestamp]
		public byte[] Version { get; set; }

		public double Pris {  get; set; }
		public int Dage {  get; set; }
		
		public int TurId {  get; set; }
		public Tur Tur {get; set;}

		public int RejseId {  get; set; }
		public Rejse Rejse {  get; set; }

	}
}
