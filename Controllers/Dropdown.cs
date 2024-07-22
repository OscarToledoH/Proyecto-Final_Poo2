using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrimerAvancePOO2.Controllers
{
    public class Dropdown : Controller
    {
        public Dropdown()
        {
        }


        public IActionResult Todos()
        {
            return View();
        }

        public IActionResult TarjetaMadre()
        {
            return View();
        }

        public IActionResult FuentePoder()
        {
            return View();
        }

        public IActionResult MemoriaRam()
        {
            return View();
        }

        public IActionResult Almacenamiento()
        {
            return View();
        }
    }
}