using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Models;
using ProyectoFinal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Controllers
{
    public class IdiomacandidController : Controller
    {
        private readonly PortalEmpleo4Context _context;

        public IdiomacandidController(PortalEmpleo4Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexIdioma()
        {
            ViewData["IdiomaId"] = new SelectList(_context.Idioma, "IdiomaId", "descripcion");
            ViewData["NiveloralidiId"] = new SelectList(_context.Niveloralidi, "NiveloralidiId", "descripcion");
            ViewData["NivescridId"] = new SelectList(_context.Nivescrid, "NivescridId", "descripcion");
            return View();
        }
        public IActionResult ListadoIdioma()
        {
            
            return PartialView();
        }
        public IActionResult NewIdioma()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexIdioma(int id,
            int idioma, int NivOral, int NivEscr
            )
        {
            var idiomacandid = new Idiomacandid()
            {

                IdiomaId = idioma,
                NiveloralidiId = NivOral,
                NivescridId = NivEscr
                

            };
            ViewData["IdiomaId"] = new SelectList(_context.Idioma, "IdiomaId", "Descripcion", idiomacandid.IdiomaId);
            ViewData["NiveloralidiId"] = new SelectList(_context.Niveloralidi, "NiveloralidiId", "Descripcion", idiomacandid.Niveloralidi);
            ViewData["NivescridId"] = new SelectList(_context.Nivescrid, "NivescridId", "Descripcion", idiomacandid.NivescridId);
            

            bool exito = true;
            if (id == -1)
                exito = await IdiomacandidRepository.Insertar(idiomacandid);
            else
            {
                idiomacandid.Ididioma = id;
                exito = await IdiomacandidRepository.Actualizar(idiomacandid);
            }
            return Json(exito);




        }
    }
}
