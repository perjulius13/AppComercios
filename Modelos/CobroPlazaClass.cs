using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class CobroPlazaClass
    {

        public int Folio { get; set; }

        public int NumeroPlaza { get; set; }

        public DateTime Fecha { get; set; }

        public double Total { get; set; }

        public bool? IsCortesia { get; set; }

        public string? TipoPuesto { get; set; }

        public int? Idusuario { get; set; }


    }
}
