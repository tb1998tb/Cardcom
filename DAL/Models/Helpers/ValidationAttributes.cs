using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	public class NumbersAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value is string)
			{
				return value.ToString().All(char.IsDigit);
			}
			return false;
		}
	}
}