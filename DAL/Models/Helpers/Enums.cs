using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public enum Gender
	{
		[Display(Name = "אחר")]
		Other,
		[Display(Name = "נקבה")]
		Female,
		[Display(Name = "זכר")]
		Male
	}
}
