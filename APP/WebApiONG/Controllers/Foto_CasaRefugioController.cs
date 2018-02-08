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
    public class Foto_CasaRefugioController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Foto_CasaRefugio
        //public IQueryable<Foto_CasaRefugio> GetFoto_CasaRefugio()
        //{
        //    return db.Foto_CasaRefugio;
        //}

        // GET: api/Foto_CasaRefugio/5
        //[ResponseType(typeof(Foto_CasaRefugio))]
        //public IHttpActionResult GetFoto_CasaRefugio(int id)
        //{
        //    Foto_CasaRefugio foto_CasaRefugio = db.Foto_CasaRefugio.Find(id);
        //    if (foto_CasaRefugio == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(foto_CasaRefugio);
        //}

        // PUT: api/Foto_CasaRefugio/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutFoto_CasaRefugio(int id, Foto_CasaRefugio foto_CasaRefugio)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != foto_CasaRefugio.cod_foto_casa)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(foto_CasaRefugio).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!Foto_CasaRefugioExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Foto_CasaRefugio
        [ResponseType(typeof(Foto_CasaRefugio))]
        //[HttpPost]
        public IHttpActionResult PostFoto_CasaRefugio(FotoCasaRefugioModelPostDTO fotoCasaRefugio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var idCasaRefugio = db.CasaRefugio.Max(x => x.cod_casa);
            db.Foto_CasaRefugio.Add(new Foto_CasaRefugio() { foto = fotoCasaRefugio.Photo, cod_casa = idCasaRefugio });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, fotoCasaRefugio);
        }

        // DELETE: api/Foto_CasaRefugio/5
        //[ResponseType(typeof(Foto_CasaRefugio))]
        //public IHttpActionResult DeleteFoto_CasaRefugio(int id)
        //{
        //    Foto_CasaRefugio foto_CasaRefugio = db.Foto_CasaRefugio.Find(id);
        //    if (foto_CasaRefugio == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Foto_CasaRefugio.Remove(foto_CasaRefugio);
        //    db.SaveChanges();

        //    return Ok(foto_CasaRefugio);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool Foto_CasaRefugioExists(int id)
        //{
        //    return db.Foto_CasaRefugio.Count(e => e.cod_foto_casa == id) > 0;
        //}
    }
}