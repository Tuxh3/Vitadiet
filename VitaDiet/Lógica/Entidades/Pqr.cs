using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VitaDiet.Lógica.Entidades
{
    public class Pqr
    {
        public string ID { set; get; }
        public string NOMBRE_PACIENTE { set; get; }
        public string CALIFICACION { set; get; }

        public Pqr(string iD, string nOMBRE_PACIENTE, string cALIFICACION)
        {
            ID = iD;
            NOMBRE_PACIENTE = nOMBRE_PACIENTE;
            CALIFICACION = cALIFICACION;
        }
    }



}