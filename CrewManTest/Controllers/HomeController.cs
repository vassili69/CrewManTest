using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrewManTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace CrewManTest.Controllers
{
    public class HomeController : Controller
    {
        //***********************************************//
        //******************LOGOUT***********************//
        //***********************************************//

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");

        }

        //***********************************************//
        //******************INDEX************************//
        //***********************************************//

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.login user)

        {
            if (ModelState.IsValid)
            {

                if (login.IsValid(user.UserName, user.Password))
                {
                    HttpContext.Session.SetString("User", "active");
                    return RedirectToAction("CrewMembers");
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

      
        //***********************************************//
        //***************CREWMEMBERS*********************//
        //***********************************************//

        public IActionResult CrewMembers(string StartsWith)
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                if (StartsWith != null)
                {
                    DataTable dt = new DataTable();
                    dt = crew.GetStoreProcLetter(StartsWith);
                    ViewData["TabelaTrip"] = dt;
                    StartsWith = null;
                    return View();
                }
                else
                return View();
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrewMembers(Models.crew crew)
            {
            if (crew.Nome != null)
            {
                DataTable dt = new DataTable();
                dt = crew.GetStoreProcSearch(crew.Nome);
                ViewData["TabelaTrip"] = dt;
                return View();
            }
            else return View();
            }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //***********************************************//
        //****************CREWCHANGE*********************//
        //***********************************************//
        
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrewChange(string StartsWith)
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                if (StartsWith != null)
                {
                    DataTable dt = new DataTable();
                    dt = crew.GetStoreProcLetter(StartsWith);
                    ViewData["TabelaTrip"] = dt;
                    StartsWith = null;
                    return View();
                }
                else
                    return View();
            }
            else return RedirectToAction("Index");
        }*/
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult CrewChange()
         {
         return View();
         }
            



    }
}
