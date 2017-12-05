﻿using System;
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
    public class MascotasController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();


        [Route("api/Mascotas/GetDogsAdoptONG")]
        public HttpResponseMessage GetDogsAdoptONG()
        {
            List<MascotaModelDTO> ListMascotaModelDTO = new List<MascotaModelDTO>();
            List<Mascota> ListMascota = new List<Mascota>();
            ListMascota = db.Mascota.Where(c => c.estado_mas.Equals("En Adopcion") && c.tenencia.Equals("ONG")).ToList();

            foreach (var item in ListMascota)
            {
                var listFotoDB = db.Foto_Mascota.Where(x => x.cod_mas == item.cod_mas).ToList();
                List<FotoMascotaModelDTO> listFotoDTO = new List<FotoMascotaModelDTO>();
                foreach (var i in listFotoDB)
                {
                    listFotoDTO.Add(new FotoMascotaModelDTO()
                    {
                        IdPhoto = i.cod_foto_mas,
                        Photo = i.foto
                    });
                }
                ListMascotaModelDTO.Add(new MascotaModelDTO() { Id = item.cod_mas,Name=item.nom_mas, Description = item.descrip_mas, Breed=item.Raza.nom_raza, Tenure = item.tenencia, State = item.estado_mas, Photos = listFotoDTO });
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListMascotaModelDTO);
        }


        [Route("api/Mascotas/GetDogsAdoptUser")]
        public HttpResponseMessage GetDogsAdoptUser()
        {
            List<MascotaModelDTO> ListMascotaModelDTO = new List<MascotaModelDTO>();
            List<Mascota> ListMascota = new List<Mascota>();
            ListMascota = db.Mascota.Where(c => c.estado_mas.Equals("En Adopcion") && c.tenencia.Equals("Usuario")).ToList();

            foreach (var item in ListMascota)
            {
                var listFotoDB = db.Foto_Mascota.Where(x => x.cod_mas == item.cod_mas).ToList();
                List<FotoMascotaModelDTO> listFotoDTO = new List<FotoMascotaModelDTO>();
                foreach (var i in listFotoDB)
                {
                    listFotoDTO.Add(new FotoMascotaModelDTO()
                    {
                        IdPhoto = i.cod_foto_mas,
                        Photo = i.foto
                    });
                }
                ListMascotaModelDTO.Add(new MascotaModelDTO() { Id = item.cod_mas, Name = item.nom_mas, Description = item.descrip_mas, Breed = item.Raza.nom_raza, Tenure = item.tenencia, State = item.estado_mas, Photos = listFotoDTO });
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListMascotaModelDTO);
        }

        [Route("api/Mascotas/GetDogsAdoptions")]
        public HttpResponseMessage GetDogsAdoptions()
        {
            List<MascotaModelDTO> ListMascotaModelDTO = new List<MascotaModelDTO>();
            List<Mascota> ListMascota = new List<Mascota>();
            ListMascota = db.Mascota.Where(c => c.estado_mas.Equals("Adoptado")).ToList();

            foreach (var item in ListMascota)
            {
                var listFotoDB = db.Foto_Mascota.Where(x => x.cod_mas == item.cod_mas).ToList();
                List<FotoMascotaModelDTO> listFotoDTO = new List<FotoMascotaModelDTO>();
                foreach (var i in listFotoDB)
                {
                    listFotoDTO.Add(new FotoMascotaModelDTO()
                    {
                        IdPhoto = i.cod_foto_mas,
                        Photo = i.foto
                    });
                }
                ListMascotaModelDTO.Add(new MascotaModelDTO() { Id = item.cod_mas, Name = item.nom_mas, Description = item.descrip_mas, Breed = item.Raza.nom_raza,Tenure=item.tenencia, State=item.estado_mas, Photos = listFotoDTO });
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListMascotaModelDTO);
        }

        // GET: api/Mascotas
        public IQueryable<Mascota> GetMascota()
        {
            return db.Mascota;
        }

        // GET: api/Mascotas/5
        [ResponseType(typeof(Mascota))]
        public IHttpActionResult GetMascota(int id)
        {
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return NotFound();
            }

            return Ok(mascota);
        }

        // PUT: api/Mascotas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMascota(int id, Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mascota.cod_mas)
            {
                return BadRequest();
            }

            db.Entry(mascota).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotaExists(id))
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

        // POST: api/Mascotas
        [ResponseType(typeof(Mascota))]
        public IHttpActionResult PostMascota(Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mascota.Add(mascota);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MascotaExists(mascota.cod_mas))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mascota.cod_mas }, mascota);
        }

        // DELETE: api/Mascotas/5
        [ResponseType(typeof(Mascota))]
        public IHttpActionResult DeleteMascota(int id)
        {
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return NotFound();
            }

            db.Mascota.Remove(mascota);
            db.SaveChanges();

            return Ok(mascota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MascotaExists(int id)
        {
            return db.Mascota.Count(e => e.cod_mas == id) > 0;
        }
    }
}