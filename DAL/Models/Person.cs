using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class Person
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "תעודת זהות הינה שדה חובה")]
		[Numbers(ErrorMessage = "על תעודת זהות להכיל מספרים בלבד")]
		public string Tz { get; set; }
		[Required(ErrorMessage = "שם הינו שדה חובה")]
		public string Name { get; set; }
		[Email(ErrorMessage = "על מייל להכיל טקסט בפורמט מייל")]
		public string Mail { get; set; }
		[Required(ErrorMessage = "תאריך לידה הינו שדה חובה")]
		public DateTime Birthdate { get; set; }
		public Gender? Gender { get; set; }
		[Numbers(ErrorMessage = "על טלפון להכיל מספרים בלבד")]
		public string Telephone { get; set; }
	}
}
