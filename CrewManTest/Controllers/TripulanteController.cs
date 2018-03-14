using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrewManTest.Models;
using Microsoft.AspNetCore.Http;
using System.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrewManTest.Controllers
{
    public class TripulanteController : Controller
    {
        // GET: /<controller>/
        public IActionResult Alerts()

        {
          
            return View();
        }

       
        public IActionResult CrewMembers()
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                return RedirectToAction("CrewMembers");
            }
            else return RedirectToAction("Index");
        }



        


    }
}
