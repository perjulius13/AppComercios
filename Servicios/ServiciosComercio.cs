using AppComercios.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace AppComercios.Servicios
{
    internal class ServiciosComercio
    {

        private readonly HttpClient _cliente = new HttpClient();


        

        public async Task<List<TipoComercioClass>> ListarTipoComercio()
        {
            var response = await _cliente.GetAsync("https://www.urbanitydata.com/api/Comercios/ListarTipoComer");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TipoComercioClass>>(json);
            }

            return new List<TipoComercioClass>();
        }

        public async Task<List<ComerciosAuxClass>> ListarComercios()
        {
            var response = await _cliente.GetAsync("https://www.urbanitydata.com/api/Comercios/ListarComercios");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ComerciosAuxClass>>(json);
            }

            return new List<ComerciosAuxClass>();
        }


        public async Task<List<CategoriaComerClass>> ListarCategorias()
        {
            var response = await _cliente.GetAsync("https://www.urbanitydata.com/api/Categorias/ListarCategorias");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CategoriaComerClass>>(json);
            }

            return new List<CategoriaComerClass>();
        }


        public async Task<bool> RegistrarComercio(ComerciosClass comer)
        {
            string url = "https://www.urbanitydata.com/api/Comercios/RegistrarComer";

            try
            {                
                HttpResponseMessage response = await _cliente.PostAsJsonAsync<ComerciosClass>(url, comer);                
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



        public async Task<CategoriaComerClass> GetCategoriaById(int idcat)
        {
            var response = await _cliente.GetAsync($"https://www.urbanitydata.com/api/Categorias/GetCategoriaById?idcat={idcat}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CategoriaComerClass>(json);
            }

            return new CategoriaComerClass();
        }


        public async Task<ComerciosAuxClass> GetComercioById(int idcomer)
        {
            var response = await _cliente.GetAsync($"https://www.urbanitydata.com/api/Comercios/GetComerById?id={idcomer}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ComerciosAuxClass>(json);
            }

            return new ComerciosAuxClass();
        }



        public async Task<bool> CobrarComercio(PagosClass pago)
        {
            string url = "https://www.urbanitydata.com/api/Pagos/RegistrarPagoLicencia";

            try
            {
                HttpResponseMessage response = await _cliente.PostAsJsonAsync<PagosClass>(url, pago);
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


        public async Task<List<VisitComerAuxClass>> ListarVisitasComercio(int iduser)
        {
            var response = await _cliente.GetAsync($"https://www.urbanitydata.com/api/Comercios/ListarVisitasComer?iduser={iduser}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VisitComerAuxClass>>(json);
            }

            return new List<VisitComerAuxClass>();
        }


        public async Task<int> GetTotalComercios()
        {
            var response = await _cliente.GetAsync($"https://www.urbanitydata.com/api/Reportes/GetTotalComercios");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(json);
            }

            return new int();
        }


    }
}
