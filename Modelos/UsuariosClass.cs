using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppComercios.Modelos
{
    public class UsuariosClass
    {
        public int IdUser { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string? Contra { get; set; }

        public string? Nombre { get; set; }

        public string? Paterno { get; set; }

        public string? Materno { get; set; }

        public int IdTipoUser { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public bool Habilitado { get; set; }

        public DateTime FechaRegistro { get; set; }

        public short? IdMunicipio { get; set; }

        public short IdEntidad { get; set; }

        public int? IdUserReg { get; set; }

        public string? UsuarioReg { get; set; }


    }
}
