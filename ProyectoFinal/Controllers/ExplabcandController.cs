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
    public class ExplabcandController : Controller
    {
        private readonly PortalEmpleo4Context _context;

        public ExplabcandController(PortalEmpleo4Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["AreatrabajoId"] = new SelectList(_context.Areatrabajo, "Id", "Descripcion");
            ViewData["CandidatoIdcandidat"] = new SelectList(_context.Candidato, "Idcandidat", "Idcandidat");
            ViewData["GiroempresaId"] = new SelectList(_context.Giroempresa, "Id", "Descripcion");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await ExplabcandRepository.Eliminar(id);
            return Json(exito);
        }
        public async Task<IActionResult> ListadoExpLab()
        {
            var portalEmpleo4Context = _context.Explabcand.Include(e => e.Areatrabajo).Include(e => e.CandidatoIdcandidatNavigation).Include(e => e.Giroempresa);
            return PartialView(await portalEmpleo4Context.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id,
           string NombreEmprEx, string Cargo, 
           DateTime Inicio, DateTime Fin, string FuncionD, int Giro, int Area )
        {
            var explabcand = new Explabcand()
            {
                Empresaexp= NombreEmprEx,
                Cargo=Cargo,
                FechaInicio=Inicio,
                FechaFin=Fin,
                Descripfuncion=FuncionD,
                GiroempresaId= Giro,
                AreatrabajoId=Area


            };
            ViewData["AreatrabajoId"] = new SelectList(_context.Areatrabajo, "Id", "Descripcion", explabcand.AreatrabajoId);
            ViewData["CandidatoIdcandidat"] = new SelectList(_context.Candidato, "Idcandidat", "Idcandidat", explabcand.CandidatoIdcandidat);
            ViewData["GiroempresaId"] = new SelectList(_context.Giroempresa, "Id", "Descripcion", explabcand.GiroempresaId);

            bool exito = true;
            if (id == -1)
                exito = await ExplabcandRepository.Insertar(explabcand);
            else
            {
                explabcand.Idexplabcand = id;
                exito = await ExplabcandRepository.Actualizar(explabcand);
            }
            return Json(exito);




        }
        //public IActionResult ListadoExpLab()
        //{
        //    return PartialView();
        //}
    }
}
