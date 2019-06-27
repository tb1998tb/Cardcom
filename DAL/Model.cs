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
