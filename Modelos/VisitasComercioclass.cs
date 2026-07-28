using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class VisitasComercioclass
    {
        public int Id { get; set; }

        public int Idcomercio { get; set; }

        public int Idusuario { get; set; }

        public bool Atendida { get; set; }

        public DateTime? FechaReg { get; set; }

        public DateTime? FechaAtencion { get; set; }

        public string? Observaciones { get; set; }

        public int IduserReg { get; set; }

    }
}
