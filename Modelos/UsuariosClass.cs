using System;
using System.Collections.Generic;
using System.Text;

namespace AppComercios.Modelos
{
    public class UsuariosClass
    {
        public int Iduser { get; set; }

        public string Telefono { get; set; } = null!;

        public string? Contra { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public bool Habilitado { get; set; }

        public DateTime? FechaAlta { get; set; }

        public int Usuarioreg { get; set; }

        public double Saldo { get; set; }


    }
}
