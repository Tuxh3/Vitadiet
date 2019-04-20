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
    public class NUTRICIONISTAsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: NUTRICIONISTAs
        public ActionResult Index()
        {
            return View(db.NUTRICIONISTA.ToList());
        }

        // GET: NUTRICIONISTAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NUTRICIONISTA nUTRICIONISTA = db.NUTRICIONISTA.Find(id);
            if (nUTRICIONISTA == null)
            {
                return HttpNotFound();
            }
            return View(nUTRICIONISTA);
        }

        // GET: NUTRICIONISTAs/Create
        public ActionResult Create()
        {
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "ID", "ROL");
            return View();
        }

        // POST: NUTRICIONISTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,APELLIDO,FECHA_NACIMIENTO,CEDULA_NUTRICIONISTA,TARJETA_PROFESIONAL,GENERO,CELULAR,CORREO,IDUSUARIO")] NUTRICIONISTA nUTRICIONISTA)
        {
            if (ModelState.IsValid)
            {
                db.NUTRICIONISTA.Add(nUTRICIONISTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "ID", "ROL", nUTRICIONISTA.IDUSUARIO);
            return View(nUTRICIONISTA);
        }

        // GET: NUTRICIONISTAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NUTRICIONISTA nUTRICIONISTA = db.NUTRICIONISTA.Find(id);
            if (nUTRICIONISTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "ID", "ROL", nUTRICIONISTA.IDUSUARIO);
            return View(nUTRICIONISTA);
        }

        // POST: NUTRICIONISTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,APELLIDO,FECHA_NACIMIENTO,CEDULA_NUTRICIONISTA,TARJETA_PROFESIONAL,GENERO,CELULAR,CORREO,IDUSUARIO")] NUTRICIONISTA nUTRICIONISTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nUTRICIONISTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "ID", "ROL", nUTRICIONISTA.IDUSUARIO);
            return View(nUTRICIONISTA);
        }

        // GET: NUTRICIONISTAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NUTRICIONISTA nUTRICIONISTA = db.NUTRICIONISTA.Find(id);
            if (nUTRICIONISTA == null)
            {
                return HttpNotFound();
            }
            return View(nUTRICIONISTA);
        }

        // POST: NUTRICIONISTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NUTRICIONISTA nUTRICIONISTA = db.NUTRICIONISTA.Find(id);
            db.NUTRICIONISTA.Remove(nUTRICIONISTA);
            db.SaveChanges();
            return RedirectToAction("Index");
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
