using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace DAL.Models
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	public class NumbersAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value == null)
				return true;
			if (value is string)
			{
				var str = value.ToString();
				return string.IsNullOrEmpty(str) || str.All(char.IsDigit);
			}
			return false;
		}
	}

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	public class EmailAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value == null)
				return true;
			if (value is string)
			{
				Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
				Match match = regex.Match(value.ToString());
				return match.Success;
			}
			return false;
		}
	}
}