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
    public class DonacionesController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Donaciones
        public IQueryable<Donaciones> GetDonaciones()
        {
            return db.Donaciones;
        }

        [Route("api/Donaciones/{shelterHouseId}/GetDonateByShelterHouse")]
        public HttpResponseMessage GetDonateByShelterHouse(int shelterHouseId)
        {
            List<DonacionModelDTO> ListDonacionModelDTO = new List<DonacionModelDTO>();
            List<Donaciones> ListDonaciones = new List<Donaciones>();
            ListDonaciones = db.Donaciones.Where(d => d.cod_casa == shelterHouseId && d.estado_don.Equals("Aceptada")).ToList();

            foreach (var item in ListDonaciones)
            {
                var listProductDB = db.DonacionProducto.Where(p => p.cod_don == item.cod_don).ToList();
                List<DonacionProductoModelDTO> listDonacionProductoDTO = new List<DonacionProductoModelDTO>();
                foreach (var i in listProductDB)
                {
                    listDonacionProductoDTO.Add(new DonacionProductoModelDTO()
                    {
                        ProductId = i.cod_pro,
                        Name = i.Producto.des_pro,
                        Quantity = i.cantidad.ToString()
                    });
                }
                ListDonacionModelDTO.Add(new DonacionModelDTO() { Id = item.cod_don, IdShelterHouse=item.cod_casa,IdUser=item.cod_usu,User = item.Usuario.usuario1,ShelterHouse=item.CasaRefugio.nom_casa, Products= listDonacionProductoDTO });
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListDonacionModelDTO);
        }

        // GET: api/Donaciones/5
        [ResponseType(typeof(Donaciones))]
        public IHttpActionResult GetDonaciones(int id)
        {
            Donaciones donaciones = db.Donaciones.Find(id);
            if (donaciones == null)
            {
                return NotFound();
            }

            return Ok(donaciones);
        }

        // PUT: api/Donaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonaciones(int id, Donaciones donaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donaciones.cod_don)
            {
                return BadRequest();
            }

            db.Entry(donaciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionesExists(id))
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

        // POST: api/Donaciones
        public IHttpActionResult PostDonaciones(DonacionModelPostDTO donaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Donaciones.Add(new Donaciones() { cod_usu=donaciones.IdUser,cod_casa=donaciones.IdShelterHouse, estado_don="En espera", fech_reg=DateTime.Now });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, donaciones);
        }

        // DELETE: api/Donaciones/5
        [ResponseType(typeof(Donaciones))]
        public IHttpActionResult DeleteDonaciones(int id)
        {
            Donaciones donaciones = db.Donaciones.Find(id);
            if (donaciones == null)
            {
                return NotFound();
            }

            db.Donaciones.Remove(donaciones);
            db.SaveChanges();

            return Ok(donaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonacionesExists(int id)
        {
            return db.Donaciones.Count(e => e.cod_don == id) > 0;
        }
    }
}