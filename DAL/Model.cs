using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
	public class CardcomContext : DbContext
	{
		public CardcomContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<Person> Persons { get; set; }

		/// <summary>
		/// save changes in db
		/// </summary>
		/// <returns>save action status</returns>
		public ActionStatus Save() {
			try
			{
				if (this.SaveChanges() > 0)
					return ActionStatus.Success;
				return ActionStatus.NoChange;
			}
			catch (Exception)
			{
				return ActionStatus.Fail;
			}
		}
	}
}
