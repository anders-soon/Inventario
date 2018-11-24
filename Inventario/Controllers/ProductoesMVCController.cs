using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;

namespace Inventario.Controllers
{
    public class ProductoesMVCController : Controller
    {
        private LaboratorioEntities db = new LaboratorioEntities();

        // GET: ProductoesMVC
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.proveedor1).Include(p => p.tipo_producto1);
            return View(producto.ToList());
        }

        // GET: ProductoesMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: ProductoesMVC/Create
        public ActionResult Create()
        {
            ViewBag.proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre");
            ViewBag.tipo_producto = new SelectList(db.tipo_producto, "id_producto", "categoria");
            return View();
        }

        // POST: ProductoesMVC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre_producto,tipo_producto,descripcion,precio,cantidad_min,cantidad_max,proveedor")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre", producto.proveedor);
            ViewBag.tipo_producto = new SelectList(db.tipo_producto, "id_producto", "categoria", producto.tipo_producto);
            return View(producto);
        }

        // GET: ProductoesMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre", producto.proveedor);
            ViewBag.tipo_producto = new SelectList(db.tipo_producto, "id_producto", "categoria", producto.tipo_producto);
            return View(producto);
        }

        // POST: ProductoesMVC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre_producto,tipo_producto,descripcion,precio,cantidad_min,cantidad_max,proveedor")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre", producto.proveedor);
            ViewBag.tipo_producto = new SelectList(db.tipo_producto, "id_producto", "categoria", producto.tipo_producto);
            return View(producto);
        }

        // GET: ProductoesMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: ProductoesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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
