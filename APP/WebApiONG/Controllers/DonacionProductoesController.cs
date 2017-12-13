using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiONG;
using WebApiONG.Models;

namespace WebApiONG.Controllers
{
    public class DonacionProductoesController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/DonacionProductoes
        public IQueryable<DonacionProducto> GetDonacionProducto()
        {
            return db.DonacionProducto;
        }

        // GET: api/DonacionProductoes/5
        [ResponseType(typeof(DonacionProducto))]
        public IHttpActionResult GetDonacionProducto(int id)
        {
            DonacionProducto donacionProducto = db.DonacionProducto.Find(id);
            if (donacionProducto == null)
            {
                return NotFound();
            }

            return Ok(donacionProducto);
        }

        // PUT: api/DonacionProductoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonacionProducto(int id, DonacionProducto donacionProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donacionProducto.cod_don)
            {
                return BadRequest();
            }

            db.Entry(donacionProducto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionProductoExists(id))
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

        // POST: api/DonacionProductoes
        [ResponseType(typeof(DonacionProducto))]
        public IHttpActionResult PostDonacionProducto(ProductoDonacionModelDTO productoDonacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idDonacion = db.Donaciones.Max(x => x.cod_don);
 
            foreach (var item in productoDonacion.ListProducts)
            {
                db.DonacionProducto.Add(new DonacionProducto() { cod_don = idDonacion, cod_pro = item.ProductId, cantidad = int.Parse(item.Quantity) });
            };

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, productoDonacion);
        }

        // DELETE: api/DonacionProductoes/5
        [ResponseType(typeof(DonacionProducto))]
        public IHttpActionResult DeleteDonacionProducto(int id)
        {
            DonacionProducto donacionProducto = db.DonacionProducto.Find(id);
            if (donacionProducto == null)
            {
                return NotFound();
            }

            db.DonacionProducto.Remove(donacionProducto);
            db.SaveChanges();

            return Ok(donacionProducto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonacionProductoExists(int id)
        {
            return db.DonacionProducto.Count(e => e.cod_don == id) > 0;
        }
    }
}