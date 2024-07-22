using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrimerAvancePOO2.Controllers
{
    public class CarroController : Controller
    {
        public CarroController()
        {
        }

        public IActionResult CarritoList()
        {
            return View();
        }
    }
}