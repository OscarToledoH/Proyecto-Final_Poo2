using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrimerAvancePOO2.Controllers
{
    public class Dropdown2 : Controller
    {
        public Dropdown2()
        {
        }


        public IActionResult Monitores()
        {
            return View();
        }

        public IActionResult Mouse()
        {
            return View();
        }

        public IActionResult Teclados()
        {
            return View();
        }
    }
}