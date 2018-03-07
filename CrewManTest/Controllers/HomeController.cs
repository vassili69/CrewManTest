using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrewManTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CrewManTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            
            return View();
        }
        public IActionResult Alerts()

        {
            var model = new Tripulante();
            model.Nome = "coco";
            model.Num = 45138;
            return View(model);
        }
        public IActionResult CrewMembers()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(string username, string password)

        {

            if (Tripulante.IsValid(username, password))
            {
                return View("CrewMembers");
            }
            else
            {
                return View("Contact");
            }
        }
           
            
            

        

    }
}
