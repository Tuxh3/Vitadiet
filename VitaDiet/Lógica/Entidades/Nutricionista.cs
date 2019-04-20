using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VitaDiet.Lógica.Entidades
{
    public class Nutricionista
    {
        public string ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public Nullable<int> CEDULA_NUTRICIONISTA { get; set; }
        public Nullable<int> TARJETA_PROFESIONAL { get; set; }
        public string GENERO { get; set; }
        public string CELULAR { get; set; }
        public string CORREO { get; set; }
        public string IDUSUARIO { get; set; }

        public Nutricionista(string iD, string nOMBRE, string aPELLIDO, DateTime fECHA_NACIMIENTO,
            int cEDULA_NUTRICIONISTA, int tARJETA_PROFESIONAL, string gENERO, string cELULAR, string cORREO, string iDUSUARIO)
        {
            ID = iD;
            NOMBRE = nOMBRE;
            APELLIDO = aPELLIDO;
            FECHA_NACIMIENTO = fECHA_NACIMIENTO;
            CEDULA_NUTRICIONISTA = cEDULA_NUTRICIONISTA;
            TARJETA_PROFESIONAL = tARJETA_PROFESIONAL;
            GENERO = gENERO;
            CELULAR = cELULAR;
            CORREO = cORREO;
            IDUSUARIO = iDUSUARIO;
            
        }
    }
}