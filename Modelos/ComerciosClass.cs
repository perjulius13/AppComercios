using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppComercios.Modelos
{
    internal class ComerciosClass
    {
        public int IdComer { get; set; }


        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string? Nombre { get; set; }

        public int IdCategoria { get; set; }

        public int IdSubcategoria { get; set; }

        public int IdTipoComercio { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, 90000, ErrorMessage = "Este campo no puede ser 0")]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        //        [Range(1,90000,ErrorMessage ="Este campo no puede ser 0")]
        public double Longitud { get; set; }

        public DateTime FechaReg { get; set; }

        public string? HoraReg { get; set; }

        public int? IdUsuarioReg { get; set; }

        public string? Usuarioreg { get; set; }

        public string? Observaciones { get; set; }

        public string? DimensionesLocal { get; set; }

        public string? LicenciaMercantil { get; set; }

        public string? IdHexa { get; set; }

        public string? Propietario { get; set; }

        public string? TelPropietario { get; set; }

        public string? EmailPropietario { get; set; }

        public string? Giro { get; set; }

        public bool MultiGiro { get; set; }

        public short IdMunicipio { get; set; }

        public short IdEntidad { get; set; }

        public bool Habilitado { get; set; }
        public bool Pagado { get; set; }


    }
}
