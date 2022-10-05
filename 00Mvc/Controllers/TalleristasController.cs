using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _04Data.Data;

namespace _00Mvc.Controllers
{
    public class TalleristasController : Controller
    {
        private VisualWorldsDbContext db = new VisualWorldsDbContext();

        // GET: Talleristas
        public ActionResult Index()
        {
            return View(db.Tallerista.ToList());
        }

        // GET: Talleristas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tallerista tallerista = db.Tallerista.Find(id);
            if (tallerista == null)
            {
                return HttpNotFound();
            }
            return View(tallerista);
        }

        // GET: Talleristas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talleristas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Apellido,Fecha_Nacimineto,Login,Pasword")] Tallerista tallerista)
        {
            if (ModelState.IsValid)
            {
                db.Tallerista.Add(tallerista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tallerista);
        }

        // GET: Talleristas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tallerista tallerista = db.Tallerista.Find(id);
            if (tallerista == null)
            {
                return HttpNotFound();
            }
            return View(tallerista);
        }

        // POST: Talleristas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Apellido,Fecha_Nacimineto,Login,Pasword")] Tallerista tallerista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tallerista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tallerista);
        }

        // GET: Talleristas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tallerista tallerista = db.Tallerista.Find(id);
            if (tallerista == null)
            {
                return HttpNotFound();
            }
            return View(tallerista);
        }

        // POST: Talleristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tallerista tallerista = db.Tallerista.Find(id);
            db.Tallerista.Remove(tallerista);
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
