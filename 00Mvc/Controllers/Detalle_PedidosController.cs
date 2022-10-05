
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
    public class Detalle_PedidosController : Controller
    {
        private VisualWorldsDbContext db = new VisualWorldsDbContext();

        // GET: Detalle_Pedidos
        public ActionResult Index()
        {
            var detalle_Pedido = db.Detalle_Pedido.Include(d => d.Pedido).Include(d => d.Proyecto);
            return View(detalle_Pedido.ToList());
        }

        // GET: Detalle_Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Pedido detalle_Pedido = db.Detalle_Pedido.Find(id);
            if (detalle_Pedido == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Pedido);
        }

        // GET: Detalle_Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.id_Pedido = new SelectList(db.Pedido, "id", "id");
            ViewBag.id_Proyecto = new SelectList(db.Proyecto, "id", "Fecha_Final");
            return View();
        }

        // POST: Detalle_Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_Proyecto,id_Pedido,Cantidad")] Detalle_Pedido detalle_Pedido)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Pedido.Add(detalle_Pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Pedido = new SelectList(db.Pedido, "id", "id", detalle_Pedido.id_Pedido);
            ViewBag.id_Proyecto = new SelectList(db.Proyecto, "id", "Fecha_Final", detalle_Pedido.id_Proyecto);
            return View(detalle_Pedido);
        }

        // GET: Detalle_Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Pedido detalle_Pedido = db.Detalle_Pedido.Find(id);
            if (detalle_Pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Pedido = new SelectList(db.Pedido, "id", "id", detalle_Pedido.id_Pedido);
            ViewBag.id_Proyecto = new SelectList(db.Proyecto, "id", "Fecha_Final", detalle_Pedido.id_Proyecto);
            return View(detalle_Pedido);
        }

        // POST: Detalle_Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_Proyecto,id_Pedido,Cantidad")] Detalle_Pedido detalle_Pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Pedido = new SelectList(db.Pedido, "id", "id", detalle_Pedido.id_Pedido);
            ViewBag.id_Proyecto = new SelectList(db.Proyecto, "id", "Fecha_Final", detalle_Pedido.id_Proyecto);
            return View(detalle_Pedido);
        }

        // GET: Detalle_Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Pedido detalle_Pedido = db.Detalle_Pedido.Find(id);
            if (detalle_Pedido == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Pedido);
        }

        // POST: Detalle_Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Pedido detalle_Pedido = db.Detalle_Pedido.Find(id);
            db.Detalle_Pedido.Remove(detalle_Pedido);
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
