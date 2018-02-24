using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrewManTest.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrewManTest.Controllers
{
    public class TripulanteController : Controller
    {
        // GET: /<controller>/
        public IActionResult Alerts()
            
        {
            var model = new Tripulante();
            model.Nome = "coco";
            model.Num = 45138;
            return View(model);
        }
    }
}
