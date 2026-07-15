using AppComercios.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace AppComercios.Servicios
{
    internal class ApiService
    {

        private readonly HttpClient _cliente = new HttpClient();


        public async Task<List<AsignacionPlazaClass>> ListarAsignaciones()
        {
            var response = await _cliente.GetAsync("https://www.urbanitydata.com/api/Cobros/ListarAsignaciones");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AsignacionPlazaClass>>(json);
            }

            return new List<AsignacionPlazaClass>();
        }


        public async Task<List<CobroPlazaClass>> ListarCobrosUser()
        {
            var response = await _cliente.GetAsync("https://www.urbanitydata.com/api/Cobros/ListarCobroPuestos");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CobroPlazaClass>>(json);
            }

            return new List<CobroPlazaClass>();
        }




        public async Task<UsuariosClass> GetDatosUser(int iduser)
        {
            var response = await _cliente.GetAsync($"https://www.urbanitydata.com/api/Usuarios/GetUserAppId?id={iduser}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsuariosClass>(json);
            }
            return new UsuariosClass();
        }


        public async Task<List<AsignacionPlazaClass>> CalendarioPuestos(int idpuesto)
        {
            var response = await _cliente.GetAsync($"https://www.urbanitydata.com/api/Cobros/GetAsignacionByPuesto?idpuesto={idpuesto}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AsignacionPlazaClass>>(json);
            }
            return new List<AsignacionPlazaClass>();
        }


        public async Task<AsignacionPlazaClass> GetAsignacionById(int id)
        {
            var response = await _cliente.GetAsync($"https://www.urbanitydata.com/api/Cobros/GetAsignacionById?ID={id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AsignacionPlazaClass>(json);
            }
            return new AsignacionPlazaClass();
        }



        public async Task<bool> CobrarPlazaApp(AsignacionPlazaClass asig)
        {
            string url = "https://www.urbanitydata.com/api/Cobros/CobrarPlazaApp";

            try
            {
                // Realiza el POST y serializa automáticamente a JSON
                HttpResponseMessage response = await _cliente.PostAsJsonAsync<AsignacionPlazaClass>(url, asig);

                // Verifica si el código de estado es un 200-299
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la petición: {ex.Message}");
            }

            return false;
        }







        public async Task<bool> ActualizarSaldoUser(UsuariosClass user )
        {
            string url = "https://www.urbanitydata.com/api/Cobros/ActualizarSaldoUserApp";

            try
            {
                // Realiza el POST y serializa automáticamente a JSON
                HttpResponseMessage response = await _cliente.PutAsJsonAsync<UsuariosClass>(url, user);

                // Verifica si el código de estado es un 200-299
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la petición: {ex.Message}");
            }

            return false;
        }





        public async Task<List<PlazaClass>> ListarPlazas()
        {
            var response = await _cliente.GetAsync("https://www.urbanitydata.com/api/Plaza/GetPlazas");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PlazaClass>>(json);
            }

            return new List<PlazaClass>();
        }


    }
}
