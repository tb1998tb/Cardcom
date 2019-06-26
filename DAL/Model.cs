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
	}
}
