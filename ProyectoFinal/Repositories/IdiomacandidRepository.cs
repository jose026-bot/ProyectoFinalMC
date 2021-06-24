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
    public class IdiomacandidRepository
    {
        public static async Task<IEnumerable<Idiomacandid>> ListadoAsincrono()
        {
            //using var data = new SalesContext();
            //var customers = await data.Customer.ToListAsync();

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:62992/api/Idiomacandid/GetIdiomacandid");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var idiomacandid = JsonConvert.DeserializeObject<IEnumerable<Idiomacandid>>(apiResponse);


            return idiomacandid;
        }



        public static async Task<Idiomacandid> Obtener(int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:62992/api/Idiomacandid/GetIdiomacandid/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var idiomacandid = JsonConvert.DeserializeObject<Idiomacandid>(apiResponse);


            return idiomacandid;
        }


        public static async Task<bool> Insertar(Idiomacandid idiomacandid)
        {
            bool exito = true;
            
            var json = JsonConvert.SerializeObject(idiomacandid);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:62992/api/Idiomacandid/PostIdiomacandid", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var Idiomacandids = JsonConvert.DeserializeObject<Idiomacandid>(apiResponse);

            if (Idiomacandids == null)
                exito = false;

            return exito;
        }


        public static async Task<bool> Actualizar(Idiomacandid idiomacandid)
        {
            bool exito = true;

            try
            {

                using var httpClient = new HttpClient();
                using var response = await httpClient
                    .GetAsync("http://localhost:62992/api/Idiomacandid/GetIdiomacandid/" + idiomacandid.Ididioma);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var idiomaByID = JsonConvert.DeserializeObject<Candidato>(apiResponse);

                //Se realizar la actualización del customer

                var json = JsonConvert.SerializeObject(idiomacandid);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var responsePut = await httpClient
                    .PutAsync("http://localhost:62992/api/Idiomacandid/PutIdiomacandid", data);

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
                  .DeleteAsync("http://localhost:62992/api/Idiomacandid/DeleteIdiomacandid/" + id);
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
