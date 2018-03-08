using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrewManTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
            
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
            if (HttpContext.Session.GetString("User") != null)
            {
                return View();
            }
            else return RedirectToAction("Index");

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(Models.Tripulante user)

        {
            if (ModelState.IsValid)
            { 
            
            if (Tripulante.IsValid(user.UserName,user.Password))
            {
                HttpContext.Session.SetString("User","active");
                return View("CrewMembers");
            }
            else
            {
                    ModelState.AddModelError("LogOnError", "O Utilizador ou Palavra chave esta errada");
                    //return RedirectToAction("Index");

                }
                
            }
         //   ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
           return View(user);
        }
           
            
            

        

    }
}
