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
    public class Foto_DenunciaController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Foto_Denuncia
        public IQueryable<Foto_Denuncia> GetFoto_Denuncia()
        {
            return db.Foto_Denuncia;
        }

        // GET: api/Foto_Denuncia/5
        [ResponseType(typeof(Foto_Denuncia))]
        public IHttpActionResult GetFoto_Denuncia(int id)
        {
            Foto_Denuncia foto_Denuncia = db.Foto_Denuncia.Find(id);
            if (foto_Denuncia == null)
            {
                return NotFound();
            }

            return Ok(foto_Denuncia);
        }

        // PUT: api/Foto_Denuncia/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFoto_Denuncia(int id, Foto_Denuncia foto_Denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foto_Denuncia.cod_foto_den)
            {
                return BadRequest();
            }

            db.Entry(foto_Denuncia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Foto_DenunciaExists(id))
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

        // POST: api/Foto_Denuncia
        [ResponseType(typeof(Foto_Denuncia))]
        public IHttpActionResult PostFoto_Denuncia(List<FotoDenunciaModelPostDTO> fotoDenuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var idDenuncia = db.Denuncia.Max(x => x.cod_den);
            foreach (var item in fotoDenuncia)
            {
                db.Foto_Denuncia.Add(new Foto_Denuncia() { foto = item.Photo, cod_den = idDenuncia });
            };

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, fotoDenuncia);
        }

        // DELETE: api/Foto_Denuncia/5
        [ResponseType(typeof(Foto_Denuncia))]
        public IHttpActionResult DeleteFoto_Denuncia(int id)
        {
            Foto_Denuncia foto_Denuncia = db.Foto_Denuncia.Find(id);
            if (foto_Denuncia == null)
            {
                return NotFound();
            }

            db.Foto_Denuncia.Remove(foto_Denuncia);
            db.SaveChanges();

            return Ok(foto_Denuncia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Foto_DenunciaExists(int id)
        {
            return db.Foto_Denuncia.Count(e => e.cod_foto_den == id) > 0;
        }
    }
}