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
    public class AdopcionsController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Adopcions
        public IQueryable<Adopcion> GetAdopcion()
        {
            return db.Adopcion;
        }

        // GET: api/Adopcions/5
        [ResponseType(typeof(Adopcion))]
        public IHttpActionResult GetAdopcion(int id)
        {
            Adopcion adopcion = db.Adopcion.Find(id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return Ok(adopcion);
        }

        // PUT: api/Adopcions/5
        [ResponseType(typeof(void))]
        public bool PutAdopcion(int id, EstadoAdopcionModelDTO estadoAdopcion)
        {
            var entity = db.Adopcion.Where(m => m.cod_mas == id).FirstOrDefault();
            entity.estado_adop = estadoAdopcion.State;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopcionExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        // POST: api/Adopcions
        [ResponseType(typeof(Adopcion))]
        public IHttpActionResult PostAdopcion(AdopcionModelDTO adopcion)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adopcion.Add(new Adopcion() { cod_usu=adopcion.IdUser, cod_mas=adopcion.IdDog, estado_adop="En espera", fecha_solic=DateTime.Now});

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, adopcion);
        }

        // DELETE: api/Adopcions/5
        [ResponseType(typeof(Adopcion))]
        public IHttpActionResult DeleteAdopcion(int id)
        {
            Adopcion adopcion = db.Adopcion.Find(id);
            if (adopcion == null)
            {
                return NotFound();
            }

            db.Adopcion.Remove(adopcion);
            db.SaveChanges();

            return Ok(adopcion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdopcionExists(int id)
        {
            return db.Adopcion.Count(e => e.cod_adop == id) > 0;
        }
    }
}