using Business.Services.WebAPI;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class PersonController : Controller
    {
        private readonly PersonService personService;
        public PersonController(PersonService _personService)
        {
            personService = _personService;
        }

        [HttpGet("get-persons")]
        public JsonResult GetPersons()
        {            
            return Json(personService.GetPersons());
        }

        [HttpGet("get-invoices")]
        public JsonResult GetInvoices()
        {
            return Json(personService.GetInvoices());
        }

        [HttpPost("add-person")]
        public JsonResult AddPerson(Person person)
        {
            return Json(personService.AddPerson(person));
        }

    }
}
