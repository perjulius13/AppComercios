using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class ComerciosAuxClass : ComerciosClass
    {
        //variables adicionales
        public string Categoriatxt { get; set; } = string.Empty;
        public string Subcategoriatxt { get; set; } = string.Empty;
        public string TipoComerciotxt { get; set; } = string.Empty;

        public string EstatusPag { get; set; } = string.Empty;


    }
}
