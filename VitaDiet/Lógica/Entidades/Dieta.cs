using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VitaDiet.Lógica.Entidades
{
    public class Dieta
    {
        public string ID { set; get; }
        public string NOMBRE { set; get; }
        public int CEDULA_PACIENTE { set; get; }
        public String COMIDA { set; get; }
        public String DOMICILIO { set; get; }

        public Dieta(string iD, string nOMBRE, int cEDULA_PACIENTE, string cOMIDA, string dOMICILIO)
        {
            ID = iD;
            NOMBRE = nOMBRE;
            CEDULA_PACIENTE = cEDULA_PACIENTE;
            COMIDA = cOMIDA;
            DOMICILIO = dOMICILIO;
        }
    }
}