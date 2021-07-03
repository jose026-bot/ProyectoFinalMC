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
    public class FormaccandController : Controller
    {
        private readonly PortalEmpleo4Context _context;

        public FormaccandController(PortalEmpleo4Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["AreaestudioId"] = new SelectList(_context.Areaestudio, "Id", "Descripcion");
            ViewData["CandidatoIdcandidat"] = new SelectList(_context.Candidato, "Idcandidat", "Idcandidat");
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Descripcion");
            ViewData["TipoestudioId"] = new SelectList(_context.Tipoestudio, "Id", "Descripcion");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await FormaccandRepository.Eliminar(id);
            return Json(exito);
        }
        public async Task<IActionResult> ListadoFormAcad()
        {
            var portalEmpleo4Context = _context.Formaccand.Include(f => f.Areaestudio).Include(f => f.CandidatoIdcandidatNavigation).Include(f => f.Pais).Include(f => f.Tipoestudio);
            return PartialView(await portalEmpleo4Context.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id,
           string CentroEduc, int TipoEstudio, string TituloCarrera, int AreaEst,
           DateTime FechIn, DateTime FechTerm, int Pais)
        {
            var formaccand = new Formaccand()
            {

                Nombrecentroed= CentroEduc,
                Fechainicio = FechIn,
                Fechafin = FechTerm,
                TipoestudioId = TipoEstudio,
                PaisId = Pais,
                AreaestudioId = AreaEst,
                Titulocarrera = TituloCarrera,
                

            };
            ViewData["AreaestudioId"] = new SelectList(_context.Areaestudio, "Id", "Descripcion", formaccand.AreaestudioId);
            ViewData["CandidatoIdcandidat"] = new SelectList(_context.Candidato, "Idcandidat", "Idcandidat", formaccand.CandidatoIdcandidat);
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Descripcion", formaccand.PaisId);
            ViewData["TipoestudioId"] = new SelectList(_context.Tipoestudio, "Id", "Descripcion", formaccand.TipoestudioId);

            bool exito = true;
            if (id == -1)
                exito = await FormaccandRepository.Insertar(formaccand);
            else
            {
                formaccand.Idformacadem = id;
                exito = await FormaccandRepository.Actualizar(formaccand);
            }
            return Json(exito);




        }
       
    }
}
