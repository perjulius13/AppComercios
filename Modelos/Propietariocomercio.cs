using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class Propietariocomercio
    {
        public int Id { get; set; }

        public int Idusuario { get; set; }

        public int Idcomercio { get; set; }

        public DateTime? FechaAlta { get; set; }

        public int? Idusuarioreg { get; set; }
    }
}
