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
    public class MaltratosController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Maltratos
        public HttpResponseMessage GetMaltrato()
        {
            List<MaltratoModelDTO> ListMaltratoModelDTO = new List<MaltratoModelDTO>();

            foreach (var i in db.Maltrato.ToList())
            {
                ListMaltratoModelDTO.Add(new MaltratoModelDTO() { ComentarioId = i.cod_mal, Descripcion = i.descrip_mal });
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListMaltratoModelDTO);
        }

        // GET: api/Maltratos/5
        [ResponseType(typeof(Maltrato))]
        public IHttpActionResult GetMaltrato(int id)
        {
            Maltrato maltrato = db.Maltrato.Find(id);
            if (maltrato == null)
            {
                return NotFound();
            }

            return Ok(maltrato);
        }

        // PUT: api/Maltratos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaltrato(int id, Maltrato maltrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maltrato.cod_mal)
            {
                return BadRequest();
            }

            db.Entry(maltrato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaltratoExists(id))
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

        // POST: api/Maltratos
        [ResponseType(typeof(Maltrato))]
        public IHttpActionResult PostMaltrato(Maltrato maltrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Maltrato.Add(maltrato);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MaltratoExists(maltrato.cod_mal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = maltrato.cod_mal }, maltrato);
        }

        // DELETE: api/Maltratos/5
        [ResponseType(typeof(Maltrato))]
        public IHttpActionResult DeleteMaltrato(int id)
        {
            Maltrato maltrato = db.Maltrato.Find(id);
            if (maltrato == null)
            {
                return NotFound();
            }

            db.Maltrato.Remove(maltrato);
            db.SaveChanges();

            return Ok(maltrato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaltratoExists(int id)
        {
            return db.Maltrato.Count(e => e.cod_mal == id) > 0;
        }
    }
}