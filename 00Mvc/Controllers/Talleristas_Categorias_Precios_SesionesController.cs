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
    public class Talleristas_Categorias_Precios_SesionesController : Controller
    {
        private VisualWorldsDbContext db = new VisualWorldsDbContext();

        // GET: Talleristas_Categorias_Precios_Sesiones
        public ActionResult Index()
        {
            var tallerista_Categoria_Precio_Sesion = db.Tallerista_Categoria_Precio_Sesion.Include(t => t.Categoria).Include(t => t.Tallerista);
            return View(tallerista_Categoria_Precio_Sesion.ToList());
        }

        // GET: Talleristas_Categorias_Precios_Sesiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tallerista_Categoria_Precio_Sesion tallerista_Categoria_Precio_Sesion = db.Tallerista_Categoria_Precio_Sesion.Find(id);
            if (tallerista_Categoria_Precio_Sesion == null)
            {
                return HttpNotFound();
            }
            return View(tallerista_Categoria_Precio_Sesion);
        }

        // GET: Talleristas_Categorias_Precios_Sesiones/Create
        public ActionResult Create()
        {
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "Tecnica");
            ViewBag.id_Tallerista = new SelectList(db.Tallerista, "id", "Nombre");
            return View();
        }
        

        // POST: Talleristas_Categorias_Precios_Sesiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_Tallerista,id_Categoria,Precio_sesion")] Tallerista_Categoria_Precio_Sesion tallerista_Categoria_Precio_Sesion)
        {
            if (ModelState.IsValid)
            {
                db.Tallerista_Categoria_Precio_Sesion.Add(tallerista_Categoria_Precio_Sesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "Tecnica", tallerista_Categoria_Precio_Sesion.id_Categoria);
            ViewBag.id_Tallerista = new SelectList(db.Tallerista, "id", "Nombre", tallerista_Categoria_Precio_Sesion.id_Tallerista);
            return View(tallerista_Categoria_Precio_Sesion);
        }

        // GET: Talleristas_Categorias_Precios_Sesiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tallerista_Categoria_Precio_Sesion tallerista_Categoria_Precio_Sesion = db.Tallerista_Categoria_Precio_Sesion.Find(id);
            if (tallerista_Categoria_Precio_Sesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "Tecnica", tallerista_Categoria_Precio_Sesion.id_Categoria);
            ViewBag.id_Tallerista = new SelectList(db.Tallerista, "id", "Nombre", tallerista_Categoria_Precio_Sesion.id_Tallerista);
            return View(tallerista_Categoria_Precio_Sesion);
        }

        // POST: Talleristas_Categorias_Precios_Sesiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_Tallerista,id_Categoria,Precio_sesion")] Tallerista_Categoria_Precio_Sesion tallerista_Categoria_Precio_Sesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tallerista_Categoria_Precio_Sesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "Tecnica", tallerista_Categoria_Precio_Sesion.id_Categoria);
            ViewBag.id_Tallerista = new SelectList(db.Tallerista, "id", "Nombre", tallerista_Categoria_Precio_Sesion.id_Tallerista);
            return View(tallerista_Categoria_Precio_Sesion);
        }

        // GET: Talleristas_Categorias_Precios_Sesiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tallerista_Categoria_Precio_Sesion tallerista_Categoria_Precio_Sesion = db.Tallerista_Categoria_Precio_Sesion.Find(id);
            if (tallerista_Categoria_Precio_Sesion == null)
            {
                return HttpNotFound();
            }
            return View(tallerista_Categoria_Precio_Sesion);
        }

        // POST: Talleristas_Categorias_Precios_Sesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tallerista_Categoria_Precio_Sesion tallerista_Categoria_Precio_Sesion = db.Tallerista_Categoria_Precio_Sesion.Find(id);
            db.Tallerista_Categoria_Precio_Sesion.Remove(tallerista_Categoria_Precio_Sesion);
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
