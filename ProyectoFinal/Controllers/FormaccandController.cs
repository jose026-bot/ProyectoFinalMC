using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Controllers
{
    public class FormaccandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListadoFormAcad()
        {
            return PartialView();
        }
    }
}
