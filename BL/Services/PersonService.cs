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
		ActionStatus SetPerson(Person person);
		ActionStatus DeletePerson(Person person);
	}

	public class PersonService : IPersonService
	{
		private CardcomContext DB;

		/// <summary>
		/// consructor
		/// </summary>
		/// <param name="db">database context</param>
		public PersonService(CardcomContext db)
		{
			this.DB = db;
		}

		/// <summary>
		/// get all persons
		/// </summary>
		/// <returns>persons list</returns>
		public WebResult<List<Person>> GetAll()
		{
			return new WebResult<List<Person>>
			{
				Success = true,
				Value = DB.Persons.ToList()
			};
		}

		/// <summary>
		/// get all genders
		/// </summary>
		/// <returns>gender list</returns>
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

		/// <summary>
		/// add or edit person
		/// </summary>
		/// <param name="person">//person data</param>
		/// <returns>status of action</returns>
		public ActionStatus SetPerson(Person person)
		{
			var originP = DB.Persons.Find(person.Id);
			if (originP != null)
			{
				originP.Mail = person.Mail;
				originP.Tz = person.Tz;
				originP.Gender = person.Gender;
				originP.Birthdate = person.Birthdate;
				originP.Name = person.Name;
				originP.Telephone = person.Telephone;
			}
			else
			{
				person.Id = 0;
				DB.Persons.Add(person);
			}
			return DB.Save();
			
		}

		/// <summary>
		/// deletes person from db
		/// </summary>
		/// <param name="person">person data</param>
		/// <returns>status of action</returns>
		public ActionStatus DeletePerson(Person person)
		{
			var originP = DB.Persons.Find(person.Id);
			if (originP != null)
			{
				DB.Persons.Remove(originP);
				return DB.Save();
				
			}
			return ActionStatus.MissingData;
		}

	}



}
