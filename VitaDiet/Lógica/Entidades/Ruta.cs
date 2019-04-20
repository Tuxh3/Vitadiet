using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VitaDiet.Lógica.Entidades
{
    public class Ruta
    {
        public string ID { get; set; }
        public string DESTINOS { get; set; }
        public string COCINAS { get; set; }
        public string DISTRIBUIDORID { get; set; }


        public Ruta(string iD, string dESTINOS, string cOCINAS, string dISTRIBUIDORID)
        {
            ID = iD;
            DESTINOS = dESTINOS;
            COCINAS = cOCINAS;
            DISTRIBUIDORID = dISTRIBUIDORID;
            
        }
    }
}