using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Entities
{
	public interface IEntity
	{
		int Id { get; set; }

		[Timestamp]
		byte[] Version { get; set; }

	}
}
