using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class Person
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "השדה הינו שדה חובה")]
		[Numbers(ErrorMessage = "על השדה להכיל מספרים בלבד")]
		public string Tz { get; set; }
		[Required(ErrorMessage = "השדה הינו שדה חובה")]
		public string Name { get; set; }
		[EmailAddress(ErrorMessage = "על השדה להכיל טקסט בפורמט מייל")]
		public string Mail { get; set; }
		[Required(ErrorMessage ="השדה הינו שדה חובה")]
		public DateTime Birthdate { get; set; }
		public Gender? Gender { get; set; }
		[Numbers(ErrorMessage = "על השדה להכיל מספרים בלבד")]
		public string Telephone { get; set; }
	
	}
}
