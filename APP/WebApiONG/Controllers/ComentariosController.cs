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
    public class ComentariosController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();


        // GET: api/Comentarios
        public IQueryable<Comentario> GetComentario()
        {
            return db.Comentario;
        }

        // GET: api/Comentarios/5
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult GetComentario(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        [Route("api/Comentarios/{complaintId}/GetCommentByComplaint")]
        public HttpResponseMessage GetCommentByComplaint(int complaintId)
        {
            List<ComentarioModelDTO> ListComentarioModelDTO = new List<ComentarioModelDTO>();
            List<Comentario> ListComentario = new List<Comentario>();
            ListComentario = db.Comentario.Where(c => c.cod_den == complaintId).ToList();

            foreach (var item in ListComentario)
            {
                ListComentarioModelDTO.Add(new ComentarioModelDTO() { Id = item.cod_com, Description = item.comen, ComplaintId = item.cod_den, UserId = item.cod_usu, User = item.Usuario.usuario1, CountLikes = (int)item.count_like });
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListComentarioModelDTO);
        }

        // PUT: api/Comentarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComentario(int id, Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentario.cod_com)
            {
                return BadRequest();
            }

            db.Entry(comentario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/Comentarios
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult PostComentario(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comentario.Add(comentario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComentarioExists(comentario.cod_com))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = comentario.cod_com }, comentario);
        }

        // DELETE: api/Comentarios/5
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult DeleteComentario(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return NotFound();
            }

            db.Comentario.Remove(comentario);
            db.SaveChanges();

            return Ok(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioExists(int id)
        {
            return db.Comentario.Count(e => e.cod_com == id) > 0;
        }
    }
}