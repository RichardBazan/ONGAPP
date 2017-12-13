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
    public class CasaRefugiosController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        //[Route("api/CasaRefugios/GetAllShelterHouse")]
        public HttpResponseMessage GetAllShelterHouse()
        {
            List<CasaRefugioModelDTO> ListCasaRefugioModelDTO = new List<CasaRefugioModelDTO>();

            foreach (var i in db.CasaRefugio.ToList())
            {
                var listFotoDB = db.Foto_CasaRefugio.Where(x => x.cod_casa == i.cod_casa).ToList();
                List<FotoCasaRefugioModelDTO> listFotoDTO = new List<FotoCasaRefugioModelDTO>();
                foreach (var item in listFotoDB)
                {
                    listFotoDTO.Add(new FotoCasaRefugioModelDTO()
                    {
                        IdPhoto = item.cod_foto_casa,
                        Photo = item.foto
                    });
                }
                ListCasaRefugioModelDTO.Add(new CasaRefugioModelDTO()
                {
                    Id = i.cod_casa,
                    Name = i.nom_casa,
                    Description = i.descrip_casa,
                    Address = i.dir_casa,
                    Phone= i.tel_cont,
                    Photos = listFotoDTO
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListCasaRefugioModelDTO);
        }

        [Route("api/CasaRefugios/{userId}/GetShelterHouseByUser")]
        public HttpResponseMessage GetAllShelterHouseByUser(int userId)
        {
            List<CasaRefugioModelDTO> ListCasaRefugioModelDTO = new List<CasaRefugioModelDTO>();
            List<CasaRefugio> ListCasaRefugio = new List<CasaRefugio>();
            ListCasaRefugio = db.CasaRefugio.Where(c => c.cod_usu == userId).ToList();

            foreach (var i in ListCasaRefugio.ToList())
            {
                var listFotoDB = db.Foto_CasaRefugio.Where(x => x.cod_casa == i.cod_casa).ToList();
                List<FotoCasaRefugioModelDTO> listFotoDTO = new List<FotoCasaRefugioModelDTO>();
                foreach (var item in listFotoDB)
                {
                    listFotoDTO.Add(new FotoCasaRefugioModelDTO()
                    {
                        IdPhoto = item.cod_foto_casa,
                        Photo = item.foto
                    });
                }
                ListCasaRefugioModelDTO.Add(new CasaRefugioModelDTO()
                {
                    Id = i.cod_casa,
                    Name = i.nom_casa,
                    Description = i.descrip_casa,
                    Address = i.dir_casa,
                    Phone = i.tel_cont,
                    Photos = listFotoDTO
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListCasaRefugioModelDTO);
        }

        // PUT: api/CasaRefugios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCasaRefugio(int id, CasaRefugio casaRefugio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != casaRefugio.cod_casa)
            {
                return BadRequest();
            }

            db.Entry(casaRefugio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasaRefugioExists(id))
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


        public IHttpActionResult PostCasaRefugio(CasaRefugioModelPostDTO casaRefugio)
        {
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CasaRefugio.Add(new CasaRefugio() {nom_casa= casaRefugio.Name, descrip_casa = casaRefugio.Description, fecha_reg=DateTime.Now ,dir_casa=casaRefugio.Address, tel_cont = casaRefugio.Phone, cod_usu=casaRefugio.IdUser});

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, casaRefugio);
        }

        // DELETE: api/CasaRefugios/5
        [ResponseType(typeof(CasaRefugio))]
        public IHttpActionResult DeleteCasaRefugio(int id)
        {
            CasaRefugio casaRefugio = db.CasaRefugio.Find(id);
            if (casaRefugio == null)
            {
                return NotFound();
            }

            db.CasaRefugio.Remove(casaRefugio);
            db.SaveChanges();

            return Ok(casaRefugio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CasaRefugioExists(int id)
        {
            return db.CasaRefugio.Count(e => e.cod_casa == id) > 0;
        }
    }
}