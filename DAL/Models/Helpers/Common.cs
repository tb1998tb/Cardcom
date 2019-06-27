using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Helpers
{
	public class IdName
	{
		public string Name { get; set; }
		public int Id { get; set; }
	}

	public class ModelStateError
	{
		public ModelError Error { get; set; }
		public ModelStateEntry Field { get; set; }
	}
}
