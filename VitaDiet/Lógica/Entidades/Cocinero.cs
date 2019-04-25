using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VitaDiet.Lógica.Entidades
{
    public class Cocinero
    {
        public string ID { set; get; }
        public string NOMBRE { set; get; }
        public int CEDULA { set; get; }
        public DateTime FECHA_NACIMIENTO { set; get; }
        public String CIUDAD  { set; get; }
        public String TELEFONO { set; get; }
        public String GENERO { set; get; }

        public Cocinero(string iD, string nOMBRE, int cEDULA, DateTime fECHA_NACIMIENTO, string cIUDAD, string tELEFONO, string gENERO)
        {
            ID = iD;
            NOMBRE = nOMBRE;
            CEDULA = cEDULA;
            FECHA_NACIMIENTO = fECHA_NACIMIENTO;
            CIUDAD = cIUDAD;
            TELEFONO = tELEFONO;
            GENERO = gENERO;

        }

    }
}