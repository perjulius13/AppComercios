using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class SolbajacomerClass
    {
        public int Id { get; set; }

        public int Idcomercio { get; set; }

        public DateTime? Fechasol { get; set; }

        public string? Motivo { get; set; }

        public bool Atendida { get; set; }

        public int? Iduseratendido { get; set; }

        public string? Respuesta { get; set; }


    }
}
