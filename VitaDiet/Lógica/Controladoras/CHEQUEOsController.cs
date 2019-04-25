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
    public class CHEQUEOsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: CHEQUEOs
        public ActionResult Index()
        {
            var cHEQUEO = db.CHEQUEO.Include(c => c.PACIENTE).Include(c => c.NUTRICIONISTA);
            return View(cHEQUEO.ToList());
        }

        // GET: CHEQUEOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHEQUEO cHEQUEO = db.CHEQUEO.Find(id);
            if (cHEQUEO == null)
            {
                return HttpNotFound();
            }
            return View(cHEQUEO);
        }

        // GET: CHEQUEOs/Create
        public ActionResult Create()
        {
            ViewBag.CEDULA_PACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE");
            ViewBag.CEDULA_NUTRICIONISTA = new SelectList(db.NUTRICIONISTA, "ID", "NOMBRE");
            return View();
        }

        // POST: CHEQUEOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CEDULA_PACIENTE,CEDULA_NUTRICIONISTA,FECHA_CHEQUEO")] CHEQUEO cHEQUEO)
        {
            if (ModelState.IsValid)
            {
                db.CHEQUEO.Add(cHEQUEO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CEDULA_PACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE", cHEQUEO.CEDULA_PACIENTE);
            ViewBag.CEDULA_NUTRICIONISTA = new SelectList(db.NUTRICIONISTA, "ID", "NOMBRE", cHEQUEO.CEDULA_NUTRICIONISTA);
            return View(cHEQUEO);
        }

        // GET: CHEQUEOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHEQUEO cHEQUEO = db.CHEQUEO.Find(id);
            if (cHEQUEO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CEDULA_PACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE", cHEQUEO.CEDULA_PACIENTE);
            ViewBag.CEDULA_NUTRICIONISTA = new SelectList(db.NUTRICIONISTA, "ID", "NOMBRE", cHEQUEO.CEDULA_NUTRICIONISTA);
            return View(cHEQUEO);
        }

        // POST: CHEQUEOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CEDULA_PACIENTE,CEDULA_NUTRICIONISTA,FECHA_CHEQUEO")] CHEQUEO cHEQUEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHEQUEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CEDULA_PACIENTE = new SelectList(db.PACIENTE, "ID", "NOMBRE", cHEQUEO.CEDULA_PACIENTE);
            ViewBag.CEDULA_NUTRICIONISTA = new SelectList(db.NUTRICIONISTA, "ID", "NOMBRE", cHEQUEO.CEDULA_NUTRICIONISTA);
            return View(cHEQUEO);
        }

        // GET: CHEQUEOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHEQUEO cHEQUEO = db.CHEQUEO.Find(id);
            if (cHEQUEO == null)
            {
                return HttpNotFound();
            }
            return View(cHEQUEO);
        }

        // POST: CHEQUEOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHEQUEO cHEQUEO = db.CHEQUEO.Find(id);
            db.CHEQUEO.Remove(cHEQUEO);
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
