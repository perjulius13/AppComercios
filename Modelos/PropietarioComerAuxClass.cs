using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class PropietarioComerAuxClass : Propietariocomercio
    {
        public string NombreComer { set; get; } = string.Empty;
        public int Zona { set; get; }
        public string TipoComercio { set; get; } = string.Empty;


    }
}
