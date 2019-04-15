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
    public class DISTRIBUIDORsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: DISTRIBUIDORs
        public ActionResult Index()
        {
            return View(db.DISTRIBUIDOR.ToList());
        }

        // GET: DISTRIBUIDORs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRIBUIDOR dISTRIBUIDOR = db.DISTRIBUIDOR.Find(id);
            if (dISTRIBUIDOR == null)
            {
                return HttpNotFound();
            }
            return View(dISTRIBUIDOR);
        }

        // GET: DISTRIBUIDORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DISTRIBUIDORs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CEDULA_NUTRICIONISTA,NOMBRE,APELLIDO,CELULAR,CORREO")] DISTRIBUIDOR dISTRIBUIDOR)
        {
            if (ModelState.IsValid)
            {
                db.DISTRIBUIDOR.Add(dISTRIBUIDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dISTRIBUIDOR);
        }

        // GET: DISTRIBUIDORs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRIBUIDOR dISTRIBUIDOR = db.DISTRIBUIDOR.Find(id);
            if (dISTRIBUIDOR == null)
            {
                return HttpNotFound();
            }
            return View(dISTRIBUIDOR);
        }

        // POST: DISTRIBUIDORs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CEDULA_NUTRICIONISTA,NOMBRE,APELLIDO,CELULAR,CORREO")] DISTRIBUIDOR dISTRIBUIDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISTRIBUIDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dISTRIBUIDOR);
        }

        // GET: DISTRIBUIDORs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRIBUIDOR dISTRIBUIDOR = db.DISTRIBUIDOR.Find(id);
            if (dISTRIBUIDOR == null)
            {
                return HttpNotFound();
            }
            return View(dISTRIBUIDOR);
        }

        // POST: DISTRIBUIDORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DISTRIBUIDOR dISTRIBUIDOR = db.DISTRIBUIDOR.Find(id);
            db.DISTRIBUIDOR.Remove(dISTRIBUIDOR);
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
