using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DAL.Models;
using DAL.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cardcom.Controllers
{
	public class BaseController : Controller
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ValidateModelState(filterContext);
			base.OnActionExecuting(filterContext);
		}

		private void ValidateModelState(ActionExecutingContext filterContext)
		{
			if (!ModelState.IsValid)
			{
				var allErrors = (from value in ModelState.Values
								 from error in value.Errors
								 select new ModelStateError { Error = error, Field = value }).ToList();
				var errors = new List<string>();
				allErrors.ForEach(f =>
					{
						if (f.Error.ErrorMessage.Contains("Error converting value {null}"))
							errors.Add($"חלק מהנתונים אינם תקינים והשרת כשל בהמרתם");
						else
							errors.Add(f.Error.ErrorMessage);
					});

				filterContext.Result = Fail<string>(string.Join("<br />", errors.Distinct()));
			}
		}

		#region Json

		protected ActionResult WebResultOk(ActionStatus status)
		{
			return Ok(new WebResult<bool>
			{
				Success = status == ActionStatus.Success,
				Message = EnumHelper<ActionStatus>.GetDisplayValue(status),
				Value = false
			});
		}



		protected ActionResult Fail<T>(string message = "", T value = default(T))
		{
			return Ok(new WebResult<T>()
			{
				Success = false,
				Value = value,
				Message = message
			});
		}
		#endregion
	}

	internal class ModelStateError
	{
		public ModelError Error { get; set; }
		public ModelStateEntry Field { get; set; }
	}
}