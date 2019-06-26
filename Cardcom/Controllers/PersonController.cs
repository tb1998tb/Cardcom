using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;

namespace Cardcom.Controllers
{
	[Route("api/[controller]")]
	public class PersonController : Controller
	{
		private IPersonService personService;
		public PersonController(IPersonService personService)
		{
			this.personService = personService;	
		}

		[Route("[action]")]
		public ActionResult GetAll() {
			return Ok(personService.GetAll());
		}

		[Route("[action]")]
		public ActionResult GetGenders() {
			return Ok(personService.GetGenders());
		}
	}
}
