using AppComercios.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Servicios
{
    internal class ServiciosComercio
    {

        private readonly HttpClient _cliente = new HttpClient();


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



    }
}
