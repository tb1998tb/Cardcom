using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cardcom.Controllers
{
	[Route("api/[controller]")]
	public class PersonController : BaseController
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

		[Route("[action]")]
		public ActionResult SetPerson([FromBody]Person person) {
			return WebResultOk(personService.SetPerson(person));
		}

		[Route("[action]")]
		public ActionResult DeletePerson([FromBody]Person person) {
			return WebResultOk(personService.DeletePerson(person));
		}
	}
}
