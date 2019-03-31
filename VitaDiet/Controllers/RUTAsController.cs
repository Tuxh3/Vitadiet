using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VitaDiet.Models;

namespace VitaDiet.Controllers
{
    public class RUTAsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: RUTAs
        public ActionResult Index()
        {
            return View(db.RUTA.ToList());
        }

        // GET: RUTAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTA rUTA = db.RUTA.Find(id);
            if (rUTA == null)
            {
                return HttpNotFound();
            }
            return View(rUTA);
        }

        // GET: RUTAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RUTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESTINOS,COCINAS")] RUTA rUTA)
        {
            if (ModelState.IsValid)
            {
                db.RUTA.Add(rUTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rUTA);
        }

        // GET: RUTAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTA rUTA = db.RUTA.Find(id);
            if (rUTA == null)
            {
                return HttpNotFound();
            }
            return View(rUTA);
        }

        // POST: RUTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESTINOS,COCINAS")] RUTA rUTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rUTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rUTA);
        }

        // GET: RUTAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTA rUTA = db.RUTA.Find(id);
            if (rUTA == null)
            {
                return HttpNotFound();
            }
            return View(rUTA);
        }

        // POST: RUTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RUTA rUTA = db.RUTA.Find(id);
            db.RUTA.Remove(rUTA);
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
