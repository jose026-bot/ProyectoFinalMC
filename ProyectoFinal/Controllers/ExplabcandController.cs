using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Controllers
{
    public class ExplabcandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListadoExpLab()
        {
            return PartialView();
        }
    }
}
