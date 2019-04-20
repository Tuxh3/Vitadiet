using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VitaDiet.Lógica.Entidades
{
    public class Paciente
    {

        public string ID { set; get; }
        public string NOMBRE { set; get; }
        public string APELLIDO { set; get; }
        public DateTime FECHA_NACIMIENTO { set; get; }
        public int CEDULA_PACIENTE { set; get; }
        public char GENERO { set; get; }
        public string RH { set; get; }
        public string DOMICILIO { set; get; }
        public string OBJETIVOS { set; get; }
        public string TIEMPO_ESPERADO { set; get; }
        public string CELULAR { set; get; }
        public string CORREO { set; get; }
        public string USUARIO_ID { set; get; }
        public string DIETA_ID { set; get; }

        public Paciente(string iD, string nOMBRE, string aPELLIDO, DateTime fECHA_NACIMIENTO, int cEDULA_PACIENTE, char gENERO, string rH, string dOMICILIO, string oBJETIVOS, string tIEMPO_ESPERADO, string cELULAR, string cORREO)
        {
            ID = iD;
            NOMBRE = nOMBRE;
            APELLIDO = aPELLIDO;
            FECHA_NACIMIENTO = fECHA_NACIMIENTO;
            CEDULA_PACIENTE = cEDULA_PACIENTE;
            GENERO = gENERO;
            RH = rH;
            DOMICILIO = dOMICILIO;
            OBJETIVOS = oBJETIVOS;
            TIEMPO_ESPERADO = tIEMPO_ESPERADO;
            CELULAR = cELULAR;
            CORREO = cORREO;
            
        }
    }
}