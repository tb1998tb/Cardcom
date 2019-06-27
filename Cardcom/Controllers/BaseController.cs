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
		/// <summary>
		/// Called after the action method is invoked
		/// </summary>
		/// <param name="filterContext">ActionExecutingContext</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ValidateModelState(filterContext);
			base.OnActionExecuting(filterContext);
		}

		/// <summary>
		/// validate all the data gotten, if match to its validation attributes
		/// </summary>
		/// <param name="filterContext">ActionExecutingContext</param>
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
		/// <summary>
		/// parse ActionStatus enum into WebResult
		/// </summary>
		/// <param name="status">status of action</param>
		/// <returns>WebResult</returns>
		protected ActionResult WebResultOk(ActionStatus status)
		{
			return Ok(new WebResult<bool>
			{
				Success = status == ActionStatus.Success,
				Message = EnumHelper<ActionStatus>.GetDisplayValue(status),
				Value = false
			});
		}


		/// <summary>
		/// parsing bad status to WebResult
		/// </summary>
		/// <typeparam name="T">generic value</typeparam>
		/// <param name="message">message for WebResult</param>
		/// <param name="value">value for WebResult</param>
		/// <returns></returns>
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
}