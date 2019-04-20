using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VitaDiet.Persistencia;

namespace VitaDiet.Lógica.Controladoras
{
    public class HISTORIALsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: HISTORIALs
        public ActionResult Index()
        {
            var hISTORIAL = db.HISTORIAL.Include(h => h.PACIENTE);
            return View(hISTORIAL.ToList());
        }

        // GET: HISTORIALs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            if (hISTORIAL == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL);
        }

        // GET: HISTORIALs/Create
        public ActionResult Create()
        {
            ViewBag.IDPACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE");
            return View();
        }

        // POST: HISTORIALs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDPACIENTE,HISTORIAL1")] HISTORIAL hISTORIAL)
        {
            if (ModelState.IsValid)
            {
                db.HISTORIAL.Add(hISTORIAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE", hISTORIAL.IDPACIENTE);
            return View(hISTORIAL);
        }

        // GET: HISTORIALs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            if (hISTORIAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE", hISTORIAL.IDPACIENTE);
            return View(hISTORIAL);
        }

        // POST: HISTORIALs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDPACIENTE,HISTORIAL1")] HISTORIAL hISTORIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORIAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE", hISTORIAL.IDPACIENTE);
            return View(hISTORIAL);
        }

        // GET: HISTORIALs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            if (hISTORIAL == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL);
        }

        // POST: HISTORIALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            db.HISTORIAL.Remove(hISTORIAL);
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
