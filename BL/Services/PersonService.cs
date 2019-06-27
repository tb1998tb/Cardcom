using DAL;
using DAL.Models;
using DAL.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
	public interface IPersonService
	{
		WebResult<List<Person>> GetAll();
		WebResult<List<IdName>> GetGenders();
		WebResult<bool> SetPerson(Person person);
	}

	public class PersonService : IPersonService
	{
		private CardcomContext DB;
		public PersonService(CardcomContext db)
		{
			this.DB = db;
		}

		public WebResult<List<Person>> GetAll()
		{
			return new WebResult<List<Person>>
			{
				Success = true,
				Value = DB.Persons.ToList()
			};
		}
		public WebResult<List<IdName>> GetGenders()
		{
			Array arr = Enum.GetValues(typeof(Gender));
			var list = new List<IdName>();
			foreach (Gender item in arr)
			{
				list.Add(new IdName
				{
					Name = EnumHelper<Gender>.GetDisplayValue(item),
					Id = (int)item
				});
			}
			return new WebResult<List<IdName>>
			{
				Success = true,
				Value = list
			};
		}

		public WebResult<bool> SetPerson(Person person)
		{
			var oldP = DB.Persons.Find(person.Id);
			if (oldP != null)
			{
				oldP.Mail = person.Mail;
				oldP.Tz = person.Tz;
				oldP.Gender = person.Gender;
				oldP.Birthdate = person.Birthdate;
				oldP.Name = person.Name;
				oldP.Telephone = person.Telephone;


			}
			else
			{
				person.Id = 0;
				DB.Persons.Add(person);
			}
			try
			{
				if (DB.SaveChanges() > 0)
					return new WebResult<bool>
					{
						Success = true,
						Message = "המידע נשמר בהצלחה",
						Value = true
					};

			}
			catch (Exception)
			{
			}
			return new WebResult<bool>
			{
				Success = false,
				Message = "תקלה בשמירת המידע, ייתכן שלא התבצעו שינויים",
				Value = false
			};
		}


	}



}
