using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Inventario.Models;

namespace Inventario.Controllers
{
    public class LaboratorioMVCController : ApiController
    {
        private LaboratorioEntities db = new LaboratorioEntities();

        // GET: api/LaboratorioMVC
        public IQueryable<producto> Getproducto()
        {
            return db.producto;
        }

        // GET: api/LaboratorioMVC/5
        [ResponseType(typeof(producto))]
        public async Task<IHttpActionResult> Getproducto(int id)
        {
            producto producto = await db.producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/LaboratorioMVC/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putproducto(int id, producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.codigo)
            {
                return BadRequest();
            }

            db.Entry(producto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LaboratorioMVC
        [ResponseType(typeof(producto))]
        public async Task<IHttpActionResult> Postproducto(producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.producto.Add(producto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = producto.codigo }, producto);
        }

        // DELETE: api/LaboratorioMVC/5
        [ResponseType(typeof(producto))]
        public async Task<IHttpActionResult> Deleteproducto(int id)
        {
            producto producto = await db.producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.producto.Remove(producto);
            await db.SaveChangesAsync();

            return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productoExists(int id)
        {
            return db.producto.Count(e => e.codigo == id) > 0;
        }
    }
}