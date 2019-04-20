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
    public class PACIENTEsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: PACIENTEs
        public ActionResult Index()
        {
            var pACIENTE = db.PACIENTE.Include(p => p.DIETA).Include(p => p.USUARIO);
            return View(pACIENTE.ToList());
        }

        // GET: PACIENTEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTE);
        }

        // GET: PACIENTEs/Create
        public ActionResult Create()
        {
            ViewBag.DIETA_ID = new SelectList(db.DIETA, "ID", "NOMBRE");
            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "ROL");
            return View();
        }

        // POST: PACIENTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,APELLIDO,FECHA_NACIMIENTO,CEDULA_PACIENTE,GENERO,RH,DOMICILIO,OBJETIVOS,TIEMPO_ESPERADO,CELULAR,CORREO,USUARIO_ID,DIETA_ID")] PACIENTE pACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.PACIENTE.Add(pACIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DIETA_ID = new SelectList(db.DIETA, "ID", "NOMBRE", pACIENTE.DIETA_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "ROL", pACIENTE.USUARIO_ID);
            return View(pACIENTE);
        }

        // GET: PACIENTEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DIETA_ID = new SelectList(db.DIETA, "ID", "NOMBRE", pACIENTE.DIETA_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "ROL", pACIENTE.USUARIO_ID);
            return View(pACIENTE);
        }

        // POST: PACIENTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,APELLIDO,FECHA_NACIMIENTO,CEDULA_PACIENTE,GENERO,RH,DOMICILIO,OBJETIVOS,TIEMPO_ESPERADO,CELULAR,CORREO,USUARIO_ID,DIETA_ID")] PACIENTE pACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DIETA_ID = new SelectList(db.DIETA, "ID", "NOMBRE", pACIENTE.DIETA_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "ROL", pACIENTE.USUARIO_ID);
            return View(pACIENTE);
        }

        // GET: PACIENTEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTE);
        }

        // POST: PACIENTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            db.PACIENTE.Remove(pACIENTE);
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
