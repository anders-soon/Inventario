using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Inventario.Controllers
{
    public class InventarioController : ApiController
    {
        private LaboratorioEntities db = new LaboratorioEntities();

        // GET: api/GetProductos
        public IQueryable<producto> GetProductos()
        {
            return db.producto.OrderBy(f => f.detalle_factura);
        }


        // GET: api/getproductos/5

        public IHttpActionResult GetProductos(int id)
        {
            producto     dimCustomer = db.producto.Find(id);
            if (dimCustomer == null)
            {
                return NotFound();
            }

            return Ok(dimCustomer);
        }
    }
}
