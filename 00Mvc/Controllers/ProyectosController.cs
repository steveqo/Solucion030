using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using _04Data.Data;

namespace _00Mvc.Controllers
{
    public class ProyectosController : Controller
    {
        private VisualWorldsDbContext db = new VisualWorldsDbContext();

        // GET: Producto
        public ActionResult Index(int? id, bool? categoria)
        {
            var productos = db.Proyecto.Include(p => p.Tallerista_Categoria_Precio_Sesion).Include(p => p.Alumno);
            //Si el método Index recibe un parámetro id != null y > 0
            if (id != null && id > 0)
            {
                if (categoria != null)
                {
                    if (categoria == true)
                    {
                        productos = productos.Where(x => x.id_Alumno == id);
                        if (productos != null && productos.Count() > 0)
                        {
                            ViewBag.Message = "Productos de la Categoría: " + productos.FirstOrDefault().Alumno.Nombre;
                        }
                    }
                    else
                    {
                        productos = productos.Where(x => x.Precio_Proyecto == id);
                        if (productos != null && productos.Count() > 0)
                        {
                            ViewBag.Message = "Productos del Proveedor: " + productos.FirstOrDefault().Alumno.Nombre
                                            + "con domicilio en: " + productos.FirstOrDefault().Alumno.Apellido + " "
                                            + productos.FirstOrDefault().Alumno.Login + " "
                                            + productos.FirstOrDefault().Alumno.Pasword + " "
                                            + productos.FirstOrDefault().Alumno.Proyecto + " ";
                        }
                    }
                }
            }
            return View(productos.ToList());
        }



        // GET: Proyectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyectos/Create
        public ActionResult Create()
        {
            ViewBag.id_Alumno = new SelectList(db.Alumno, "id", "Nombre");
            ViewBag.id_Tallerista_Categoria_Precio_Sesion = new SelectList(db.Tallerista_Categoria_Precio_Sesion, "id", "id");
            return View();
        }

        // POST: Proyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_Alumno,id_Tallerista_Categoria_Precio_Sesion,Fecha_Inicio,Fecha_Final,Precio_Proyecto,Numero_sesiones")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Alumno = new SelectList(db.Alumno, "id", "Nombre", proyecto.id_Alumno);
            ViewBag.id_Tallerista_Categoria_Precio_Sesion = new SelectList(db.Tallerista_Categoria_Precio_Sesion, "id", "id", proyecto.id_Tallerista_Categoria_Precio_Sesion);
            return View(proyecto);
        }

        // GET: Proyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Alumno = new SelectList(db.Alumno, "id", "Nombre", proyecto.id_Alumno);
            ViewBag.id_Tallerista_Categoria_Precio_Sesion = new SelectList(db.Tallerista_Categoria_Precio_Sesion, "id", "id", proyecto.id_Tallerista_Categoria_Precio_Sesion);
            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_Alumno,id_Tallerista_Categoria_Precio_Sesion,Fecha_Inicio,Fecha_Final,Precio_Proyecto,Numero_sesiones")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Alumno = new SelectList(db.Alumno, "id", "Nombre", proyecto.id_Alumno);
            ViewBag.id_Tallerista_Categoria_Precio_Sesion = new SelectList(db.Tallerista_Categoria_Precio_Sesion, "id", "id", proyecto.id_Tallerista_Categoria_Precio_Sesion);
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
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
