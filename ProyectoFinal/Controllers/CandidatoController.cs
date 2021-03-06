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
    public class CandidatoController : Controller
    {
        private readonly PortalEmpleo4Context _context;

       public CandidatoController(PortalEmpleo4Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    

        public IActionResult PerfilCandidato()
        {
            return View();
        }
       
        
        
        public IActionResult ListadoHabilidades()
        {
            return PartialView();
        }
        public IActionResult Create()
        {
            
            return View();

        }
        public async Task<IActionResult> Listado()
        {
            var candidato = await CandidatoRepository.ListadoAsincrono();
            return PartialView(candidato);
        }
        [HttpPost]
        public async Task<IActionResult> EliminarAsync(int idCandidato)
        {
            bool exito = await CandidatoRepository.Eliminar(idCandidato);
            return Json(exito);
        }
        public IActionResult NewCandidato()
        {
            ViewData["EstadocivilIdestciv"] = new SelectList(_context.Estadocivil, "Idestciv", "Descripcion");
            ViewData["GeneroIdgenero"] = new SelectList(_context.Genero, "Idgenero", "Descripcion");
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> NewCandidato(int id,
            string nombre, string apellido, DateTime fechanac, int estadociv,
            string telef, int genero, string descrp, string contra)
        {
            var candidato = new Candidato()
            {

                Nombres = nombre,
                Apellidos=apellido,
                Fechanacim=fechanac,
                EstadocivilIdestciv=estadociv,
                Telefono=telef,
                GeneroIdgenero=genero,
                Descrpperfil=descrp,
                Contraseña=contra
                
            };
            ViewData["EstadocivilIdestciv"] = new SelectList(_context.Estadocivil, "Idestciv", "Descripcion", candidato.EstadocivilIdestciv);
            ViewData["GeneroIdgenero"] = new SelectList(_context.Genero, "Idgenero", "Descripcion", candidato.GeneroIdgenero);

            bool exito = true;
            if (id == -1)
                exito = await CandidatoRepository.Insertar(candidato);
            else
            {
                candidato.Idcandidat = id;
                exito = await CandidatoRepository.Actualizar(candidato);
            }
            return Json(exito);
            

            

        }
        





    }
}
