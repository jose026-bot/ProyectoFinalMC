using Newtonsoft.Json;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositories
{
    public class CandidatoRepository
    {
        public static async Task<IEnumerable<Candidato>> ListadoAsincrono()
        {
            //using var data = new SalesContext();
            //var customers = await data.Customer.ToListAsync();

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:62992/api/Candidato/GetCandidato");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var candidato = JsonConvert.DeserializeObject<IEnumerable<Candidato>>(apiResponse);


            return candidato;
        }



        public static async Task<Candidato> Obtener(int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:62992/api/Candidato/GetCandidatoById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var candidato = JsonConvert.DeserializeObject<Candidato>(apiResponse);


            return candidato;
        }


        public static async Task<bool> Insertar(Candidato Candidato)
        {
            bool exito = true;

            var json = JsonConvert.SerializeObject(Candidato);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:62992/api/Candidato/PostCandidato", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var candidato = JsonConvert.DeserializeObject<Candidato>(apiResponse);
            if (candidato == null)
                exito = false;

            return exito;
        }


        public static async Task<bool> Actualizar(Candidato Candidato)
        {
            bool exito = true;

            try
            {

                using var httpClient = new HttpClient();
                using var response = await httpClient
                    .GetAsync("http://localhost:62992/api/Candidato/PutCandidato/" + Candidato.Idcandidat);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var customerByID = JsonConvert.DeserializeObject<Candidato>(apiResponse);

                //Se realizar la actualización del customer

                var json = JsonConvert.SerializeObject(Candidato);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var responsePut = await httpClient
                    .PutAsync("http://localhost:41984/api/Customer/PutCustomer", data);

                string apiResponsePut = await responsePut.Content.ReadAsStringAsync();
                var customerResponse = JsonConvert.DeserializeObject<Candidato>(apiResponsePut);
                if (customerResponse == null)
                    exito = false;


            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }

        public static async Task<bool> Eliminar(int id)
        {
            bool exito = true;

            try
            {

                using var httpClient = new HttpClient();



                using var responseDelete = await httpClient
                  .DeleteAsync("http://localhost:62992/api/Candidato/DeleteCandidato/" + id);
                string apiResponseDelete = await responseDelete.Content.ReadAsStringAsync();
                if ((int)responseDelete.StatusCode == 404)
                    exito = false;


            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }



    }
}
