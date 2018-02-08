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
    public class Foto_MascotaController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Foto_Mascota
        public IQueryable<Foto_Mascota> GetFoto_Mascota()
        {
            return db.Foto_Mascota;
        }

        // GET: api/Foto_Mascota/5
        [ResponseType(typeof(Foto_Mascota))]
        public IHttpActionResult GetFoto_Mascota(int id)
        {
            Foto_Mascota foto_Mascota = db.Foto_Mascota.Find(id);
            if (foto_Mascota == null)
            {
                return NotFound();
            }

            return Ok(foto_Mascota);
        }

        // PUT: api/Foto_Mascota/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFoto_Mascota(int id, Foto_Mascota foto_Mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foto_Mascota.cod_foto_mas)
            {
                return BadRequest();
            }

            db.Entry(foto_Mascota).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Foto_MascotaExists(id))
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

        // POST: api/Foto_Mascota
        [ResponseType(typeof(Foto_Mascota))]
        public IHttpActionResult PostFoto_Mascota(FotoMascotaModelPostDTO fotoMascota)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var idMascota = db.Mascota.Max(x => x.cod_mas);
            db.Foto_Mascota.Add(new Foto_Mascota() { foto = fotoMascota.Photo, cod_mas = idMascota });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, fotoMascota);
        }

        // DELETE: api/Foto_Mascota/5
        [ResponseType(typeof(Foto_Mascota))]
        public IHttpActionResult DeleteFoto_Mascota(int id)
        {
            Foto_Mascota foto_Mascota = db.Foto_Mascota.Find(id);
            if (foto_Mascota == null)
            {
                return NotFound();
            }

            db.Foto_Mascota.Remove(foto_Mascota);
            db.SaveChanges();

            return Ok(foto_Mascota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Foto_MascotaExists(int id)
        {
            return db.Foto_Mascota.Count(e => e.cod_foto_mas == id) > 0;
        }
    }
}