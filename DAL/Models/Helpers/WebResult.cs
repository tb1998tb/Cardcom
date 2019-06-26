using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Helpers
{
	public class WebResult<T>
	{
		public bool Success;
		public string Message;
		public T Value;
	}
}
