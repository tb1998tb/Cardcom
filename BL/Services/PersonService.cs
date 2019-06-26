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
		public WebResult<List<IdName>> GetGenders() {
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
			return new WebResult<List<IdName>> {
				Success=true,
				Value=list
			};
		}


	}

	

}
