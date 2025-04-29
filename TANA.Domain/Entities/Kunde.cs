using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
	public class Kunde : IEntity
	{
		public int Id { get; set; }
		[Timestamp]
		public byte[] Version { get; set; }

		public string Navn { get; set; }
		public string Email {  get; set; }
		public string Adresse { get; set; }
		public int TelefonNr { get; set; }

		public string Status {  get; set; }
	}
}
