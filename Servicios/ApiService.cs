using AppComercios.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Servicios
{
    internal class ApiService
    {

        private readonly HttpClient _cliente = new HttpClient();


        public async Task<List<AsingacionPlazaClass>> ListarAsignaciones()
        {
            var response = await _cliente.GetAsync("https://www.urbanitydata.com/api/Cobros/ListarAsignaciones");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AsingacionPlazaClass>>(json);
            }

            return new List<AsingacionPlazaClass>();
        }



    }
}
