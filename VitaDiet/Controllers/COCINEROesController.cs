using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VitaDiet.Persistencia;

namespace VitaDiet.Controllers
{
    public class COCINEROesController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: COCINEROes
        public ActionResult Index()
        {
            var cOCINERO = db.COCINERO.Include(c => c.COCINASet).Include(c => c.USUARIO);
            return View(cOCINERO.ToList());
        }

        // GET: COCINEROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COCINERO cOCINERO = db.COCINERO.Find(id);
            if (cOCINERO == null)
            {
                return HttpNotFound();
            }
            return View(cOCINERO);
        }

        // GET: COCINEROes/Create
        public ActionResult Create()
        {
            ViewBag.COCINAId = new SelectList(db.COCINASet, "Id", "UBICACION");
            ViewBag.USUARIOID = new SelectList(db.USUARIO, "ID", "ROL");
            return View();
        }

        // POST: COCINEROes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,CEDULA,FECHA_NACIMIENTO,CIUDAD,GENERO,TELEFONO,USUARIOID,COCINAId")] COCINERO cOCINERO)
        {
            if (ModelState.IsValid)
            {
                db.COCINERO.Add(cOCINERO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COCINAId = new SelectList(db.COCINASet, "Id", "UBICACION", cOCINERO.COCINAId);
            ViewBag.USUARIOID = new SelectList(db.USUARIO, "ID", "ROL", cOCINERO.USUARIOID);
            return View(cOCINERO);
        }

        // GET: COCINEROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COCINERO cOCINERO = db.COCINERO.Find(id);
            if (cOCINERO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COCINAId = new SelectList(db.COCINASet, "Id", "UBICACION", cOCINERO.COCINAId);
            ViewBag.USUARIOID = new SelectList(db.USUARIO, "ID", "ROL", cOCINERO.USUARIOID);
            return View(cOCINERO);
        }

        // POST: COCINEROes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,CEDULA,FECHA_NACIMIENTO,CIUDAD,GENERO,TELEFONO,USUARIOID,COCINAId")] COCINERO cOCINERO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOCINERO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COCINAId = new SelectList(db.COCINASet, "Id", "UBICACION", cOCINERO.COCINAId);
            ViewBag.USUARIOID = new SelectList(db.USUARIO, "ID", "ROL", cOCINERO.USUARIOID);
            return View(cOCINERO);
        }

        // GET: COCINEROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COCINERO cOCINERO = db.COCINERO.Find(id);
            if (cOCINERO == null)
            {
                return HttpNotFound();
            }
            return View(cOCINERO);
        }

        // POST: COCINEROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COCINERO cOCINERO = db.COCINERO.Find(id);
            db.COCINERO.Remove(cOCINERO);
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
