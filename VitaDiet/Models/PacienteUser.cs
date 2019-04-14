using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitaDiet.Models
{
    public class PacienteUser
    {
        [Required]
        public string ID { get; set; }
        public string ROL { get; set; }
        [Required]
        public string CONTRASENA { get; set; }
        [Required]
        public string USERNAME { get; set; }
        [Required]
        public string NOMBRE { get; set; }
        [Required]
        public string APELLIDO { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        [Range(0,99999999999)]
        [Required]
        public Nullable<int> CEDULA_PACIENTE { get; set; }
        [StringLength(3)]
        public string GENERO { get; set; }
        public string RH { get; set; }
        public string DOMICILIO { get; set; }
        public string OBJETIVOS { get; set; }
        public string TIEMPO_ESPERADO { get; set; }
        public string CELULAR { get; set; }
        [Required]
        [EmailAddress]
        public string CORREO { get; set; }
    }
}