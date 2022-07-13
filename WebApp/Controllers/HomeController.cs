using Business.Services.WebApp;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PersonAppService _personService;
        public HomeController(ILogger<HomeController> logger, PersonAppService personAppService)
        {
            _logger = logger;
            _personService = personAppService;
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("kisi-listesi")]
        public IActionResult PersonList()
        {
            return View(_personService.GetPersons().Datas);
        }

        [HttpGet("kisi-ekle")]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost("kisi-ekle")]
        public JsonResult PersonAdd(Person person)
        {
            return Json(_personService.AddPerson(person).Result);
        }
    }
}
