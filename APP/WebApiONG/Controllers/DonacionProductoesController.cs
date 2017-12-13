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

        // POST: api/DonacionProductoes
        //public IHttpActionResult PostDonacionProducto(ProductosDonadosModelDTO donacionProducto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var idDonacion = db.Donaciones.Max(x => x.cod_don);
        //    db.DonacionProducto.Add(new DonacionProducto() { cod_don = idDonacion, cod_pro=donacionProducto. });

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException e)
        //    {
        //        e.GetBaseException();
        //    }

        //    return CreatedAtRoute("DefaultApi", null, donacionProducto);
        //}

       

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