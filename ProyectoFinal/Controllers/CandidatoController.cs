using Microsoft.AspNetCore.Mvc;
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
        public IActionResult ListadoExpLab()
        {
            return PartialView();
        }
        public IActionResult ListadoFormAcad()
        {
            return PartialView();
        }
        public IActionResult ListadoIdioma()
        {
            return PartialView();
        }
        public IActionResult ListadoHabilidades()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> CREAR(int id,
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
