using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class PagosClass
    {
        public int IdPeticion { get; set; }

        public int IdComercio { get; set; }

        public int Cantidad { get; set; }

        public double Total { get; set; }

        public double? Importe { get; set; }

        public DateTime Fechapago { get; set; }

        public string? HoraPago { get; set; }

        public int IdUserReg { get; set; }

        public bool Cancelado { get; set; }

        public DateTime? FechaCancelacion { get; set; }

        public int? IdUserCancelo { get; set; }

    }
}
