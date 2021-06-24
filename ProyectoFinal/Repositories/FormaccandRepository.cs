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
    public class FormaccandRepository
    {
        public static async Task<IEnumerable<Formaccand>> ListadoAsincrono()
        {
            //using var data = new SalesContext();
            //var customers = await data.Customer.ToListAsync();

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:62992/api/Formaccand/GetFormaccand");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var formaccands = JsonConvert.DeserializeObject<IEnumerable<Formaccand>>(apiResponse);


            return formaccands;
        }



        public static async Task<Formaccand> Obtener(int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:62992/api/Formaccand/GetFormaccandById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var formaccands = JsonConvert.DeserializeObject<Formaccand>(apiResponse);


            return formaccands;
        }


        public static async Task<bool> Insertar(Formaccand formaccand)
        {
            bool exito = true;

            var json = JsonConvert.SerializeObject(formaccand);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:62992/api/Formaccand/PostFormaccand", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var explabcands = JsonConvert.DeserializeObject<Formaccand>(apiResponse);

            if (formaccand == null)
                exito = false;

            return exito;
        }


        public static async Task<bool> Actualizar(Formaccand formaccand)
        {
            bool exito = true;

            try
            {

                using var httpClient = new HttpClient();
                using var response = await httpClient
                    .GetAsync("http://localhost:62992/api/Formaccand/GetFormaccandById/" + formaccand.Idformacadem);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var customerByID = JsonConvert.DeserializeObject<Formaccand>(apiResponse);

                //Se realizar la actualización del customer

                var json = JsonConvert.SerializeObject(formaccand);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var responsePut = await httpClient
                    .PutAsync("http://localhost:62992/api/Formaccand/PutFormaccand/", data);

                string apiResponsePut = await responsePut.Content.ReadAsStringAsync();
                var customerResponse = JsonConvert.DeserializeObject<Formaccand>(apiResponsePut);
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
                  .DeleteAsync("http://localhost:62992/api/Formaccand/DeleteFormaccand/" + id);
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

