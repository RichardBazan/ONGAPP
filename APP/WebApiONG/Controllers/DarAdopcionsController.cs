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
    public class DarAdopcionsController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // POST: api/DarAdopcions
        public IHttpActionResult PostDarAdopcion(DarEnAdopcionModelDTO darAdopcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var idMascota = db.Mascota.Max(x => x.cod_mas);
            db.DarAdopcion.Add(new DarAdopcion() { fecha_reg=DateTime.Now, cod_usu=darAdopcion.IdUser,cod_mas= idMascota });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, darAdopcion);
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DarAdopcionExists(int id)
        {
            return db.DarAdopcion.Count(e => e.cod_daradop == id) > 0;
        }
    }
}