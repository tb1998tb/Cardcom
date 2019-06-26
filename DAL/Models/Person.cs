using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class Person
	{
		public int Id { get; set; }
		[Required]
		[Numbers]
		public string Tz { get; set; }
		[Required]
		public string Name { get; set; }
		public string Mail { get; set; }
		[Required]
		public DateTime Birthdate { get; set; }
		public Gender? Gender { get; set; }
		[Numbers]
		public string Telephone { get; set; }
	
	}
}
