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
using WebApiONG.Models;
using WebApiONG;

namespace WebApiONG.Controllers
{
    public class RazasController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Razas
        [Route("api/Razas/GetAllBreed")]

        public HttpResponseMessage GetRaza()
        {
            List<RazaModelDTO> ListRazaModelDTO = new List<RazaModelDTO>();
            
            foreach (var i in db.Raza.ToList())
            {
                ListRazaModelDTO.Add(new RazaModelDTO() { Id = i.cod_raza, Name = i.nom_raza });
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListRazaModelDTO);
        }

        // GET: api/Razas/5
        //[ResponseType(typeof(RazaModelDTO))]
        [Route("api/Razas/{id}/GetRazaById")]
        public HttpResponseMessage GetRaza(int id)
        {
            Raza raza = db.Raza.Find(id);

            
            if (raza == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            RazaModelDTO razaById = new RazaModelDTO() { Id = raza.cod_raza, Name = raza.nom_raza };

            return Request.CreateResponse(HttpStatusCode.OK, razaById);
        }

        // PUT: api/Razas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRaza(int id, Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raza.cod_raza)
            {
                return BadRequest();
            }

            db.Entry(raza).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazaExists(id))
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

        // POST: api/Razas
        [ResponseType(typeof(Raza))]
        public IHttpActionResult PostRaza(Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Raza.Add(raza);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RazaExists(raza.cod_raza))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = raza.cod_raza }, raza);
        }

        // DELETE: api/Razas/5
        [ResponseType(typeof(Raza))]
        public IHttpActionResult DeleteRaza(int id)
        {
            Raza raza = db.Raza.Find(id);
            
            if (raza == null)
            {
                return NotFound();
            }

            db.Raza.Remove(raza);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RazaExists(int id)
        {
            return db.Raza.Count(e => e.cod_raza == id) > 0;
        }
    }
}