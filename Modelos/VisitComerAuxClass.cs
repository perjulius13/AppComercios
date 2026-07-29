using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class VisitComerAuxClass : VisitasComercioclass
    {
        public string NombreComer { set; get; } = string.Empty;
        public string NombreUser { set; get; } = string.Empty;
        public int Zona { set; get; }
        public int IDcategoria { set; get; }

    }



}
