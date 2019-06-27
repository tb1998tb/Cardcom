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

	public enum ActionStatus
	{
		[Display(Name = "השרת כשל בביצוע הפעולה, נסה שנית מאוחר יותר")]
		Fail,
		[Display(Name = "תקלה בשמירת המידע, ייתכן שלא התבצעו שינויים")]
		NoChange,
		[Display(Name = "המידע נשמר בהצלחה")]
		Success,
		[Display(Name = "חלק מהנתונים חסרים או שהאיש אינו קיים במערכת")]
		MissingData
	}
}
