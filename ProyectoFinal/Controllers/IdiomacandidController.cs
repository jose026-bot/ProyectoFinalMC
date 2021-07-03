using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            ViewData["IdiomaId"] = new SelectList(_context.Idioma, "Id", "Descripcion");
            ViewData["NiveloralidiId"] = new SelectList(_context.Niveloralidi, "Id", "Descripcion");
            ViewData["NivescridId"] = new SelectList(_context.Nivescrid, "Id", "Descripcion");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await IdiomacandidRepository.Eliminar(id);
            return Json(exito);
        }
        public async Task<IActionResult> ListadoIdioma()
        {
            var portalEmpleo4Context = _context.Idiomacandid.Include(i => i.CandidatoIdcandidatNavigation).Include(i =>
            i.Idioma).Include(i => i.Niveloralidi).Include(i => i.Nivescrid);

            return PartialView(await portalEmpleo4Context.ToListAsync());
        }
       
        public async Task<IActionResult> Obtener(int id)
        {
            var idiomacand = await IdiomacandidRepository.Obtener(id);
            //ViewData["IdiomaId"] = new SelectList(_context.Idioma, "Id", "Descripcion", idiomacandid.IdiomaId);
            //ViewData["NiveloralidiId"] = new SelectList(_context.Niveloralidi, "Id", "Descripcion", idiomacandid.Niveloralidi);
            //ViewData["NivescridId"] = new SelectList(_context.Nivescrid, "Id", "Descripcion", idiomacandid.NivescridId);

            return Json(idiomacand);
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
            ViewData["IdiomaId"] = new SelectList(_context.Idioma, "Id", "Descripcion", idiomacandid.IdiomaId);
            ViewData["NiveloralidiId"] = new SelectList(_context.Niveloralidi, "Id", "Descripcion", idiomacandid.Niveloralidi);
            ViewData["NivescridId"] = new SelectList(_context.Nivescrid, "Id", "Descripcion", idiomacandid.NivescridId);
            

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
