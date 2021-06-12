using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Controllers
{
    public class CandidatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewCandidato()
        {
            return View();
        }

        public IActionResult PerfilCandidato()
        {
            return View();
        }


    }
}
