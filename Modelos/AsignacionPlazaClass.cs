using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    internal class AsignacionPlazaClass
    {

        public int Id { get; set; }

        public int IdPuesto { get; set; }

        public int NumeroPlaza { get; set; }

        public DateTime FechaAsig { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int? IduserReg { get; set; }

        public bool Pagado { get; set; }

        public double? CostoPlaza { get; set; }



    }
}
