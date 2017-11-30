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
    public class DenunciasController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        [Route("api/Maltratos/GetAllComplaints")]
        public HttpResponseMessage GetMaltrato()
        {
            List<DenunciaModelDTO> ListMaltratoModelDTO = new List<DenunciaModelDTO>();

            foreach (var i in db.Denuncia.ToList())
            {
                var listFotoDB = db.Foto_Denuncia.Where(x => x.cod_den == i.cod_den).ToList();
                List<FotoDenunciaModelDTO> listFotoDTO = new List<FotoDenunciaModelDTO>();
                foreach (var item in listFotoDB)
                {
                    listFotoDTO.Add(new FotoDenunciaModelDTO()
                    {
                        IdPhoto = item.cod_foto_den,
                        Photo = item.foto
                    });
                }
                ListMaltratoModelDTO.Add(new DenunciaModelDTO()
                {
                    Id = i.cod_den,
                    Title = i.titulo_den,
                    Description = i.descrip_den,
                    Photos = listFotoDTO
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListMaltratoModelDTO);
        }

        [Route("api/Maltratos/{userId}/GetComplaintByUser")]
        public HttpResponseMessage GetCommentByComplaint(int userId)
        {
            List<DenunciaModelDTO> ListMaltratoModelDTO = new List<DenunciaModelDTO>();
            List<Denuncia> ListMaltrato = new List<Denuncia>();
            ListMaltrato = db.Denuncia.Where(m => m.cod_usu == userId).ToList();

            foreach (var i in ListMaltrato)
            {
                var listFotoDB = db.Foto_Denuncia.Where(x => x.cod_den == i.cod_den).ToList();
                List<FotoDenunciaModelDTO> listFotoDTO = new List<FotoDenunciaModelDTO>();
                foreach (var item in listFotoDB)
                {
                    listFotoDTO.Add(new FotoDenunciaModelDTO()
                    {
                        IdPhoto = item.cod_foto_den,
                        Photo = item.foto
                    });
                }
                ListMaltratoModelDTO.Add(new DenunciaModelDTO() {
                    Id = i.cod_den,
                    Title = i.titulo_den,
                    Description = i.descrip_den,
                    Photos = listFotoDTO
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListMaltratoModelDTO);
        }

        // GET: api/Maltratos/5
        [ResponseType(typeof(Denuncia))]
        public IHttpActionResult GetMaltrato(int id)
        {
            Denuncia denuncia = db.Denuncia.Find(id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return Ok(denuncia);
        }

        // PUT: api/Maltratos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaltrato(int id, Denuncia denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denuncia.cod_den)
            {
                return BadRequest();
            }

            db.Entry(denuncia).State = EntityState.Modified;

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
        [ResponseType(typeof(Denuncia))]
        public IHttpActionResult PostMaltrato(Denuncia denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Denuncia.Add(denuncia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MaltratoExists(denuncia.cod_den))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = denuncia.cod_den }, denuncia);
        }

        // DELETE: api/Maltratos/5
        [ResponseType(typeof(Denuncia))]
        public IHttpActionResult DeleteMaltrato(int id)
        {
            Denuncia denuncia = db.Denuncia.Find(id);
            if (denuncia == null)
            {
                return NotFound();
            }

            db.Denuncia.Remove(denuncia);
            db.SaveChanges();

            return Ok(denuncia);
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
            return db.Denuncia.Count(e => e.cod_den == id) > 0;
        }
    }
}