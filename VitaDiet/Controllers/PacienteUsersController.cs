using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VitaDiet.Models;
using VitaDiet.Persistencia;

namespace VitaDiet.Controllers
{
    public class PacienteUsersController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: PacienteUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacienteUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USERNAME,CONTRASENA,NOMBRE,APELLIDO,FECHA_NACIMIENTO,CEDULA_PACIENTE,GENERO,RH,DOMICILIO,OBJETIVOS,TIEMPO_ESPERADO,CELULAR,CORREO")] PacienteUser pacienteUser)
        {
            if (ModelState.IsValid)
            {
                PACIENTE pACIENTE = new PACIENTE();
                pACIENTE.ID = pacienteUser.ID;
                pACIENTE.NOMBRE = pacienteUser.NOMBRE;
                pACIENTE.APELLIDO = pacienteUser.APELLIDO;
                pACIENTE.FECHA_NACIMIENTO = pacienteUser.FECHA_NACIMIENTO;
                pACIENTE.CEDULA_PACIENTE = pacienteUser.CEDULA_PACIENTE;
                pACIENTE.GENERO = pacienteUser.GENERO;
                pACIENTE.RH = pacienteUser.RH;
                pACIENTE.DOMICILIO = pacienteUser.DOMICILIO;
                pACIENTE.OBJETIVOS = pacienteUser.OBJETIVOS;
                pACIENTE.TIEMPO_ESPERADO = pacienteUser.TIEMPO_ESPERADO;
                pACIENTE.CELULAR = pacienteUser.CELULAR;
                pACIENTE.CORREO = pacienteUser.CORREO;

                USUARIO uSUARIO = new USUARIO();
                uSUARIO.ID = pacienteUser.ID;
                uSUARIO.USERNAME = pacienteUser.USERNAME;
                uSUARIO.ROL = "PACIENTE";
                uSUARIO.CONTRASENA = pacienteUser.CONTRASENA;

                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                db.PACIENTE.Add(pACIENTE);
                db.SaveChanges();
                //db.PacienteUsers.Add(pacienteUser);
                return RedirectToAction("Create");
            }

            return View(pacienteUser);
        }

        // POST: PacienteUsers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ROL,CONTRASENA,NOMBRE,APELLIDO,FECHA_NACIMIENTO,CEDULA_PACIENTE,GENERO,RH,DOMICILIO,OBJETIVOS,TIEMPO_ESPERADO,CELULAR,CORREO")] PacienteUser pacienteUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacienteUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacienteUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
