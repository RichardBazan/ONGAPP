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

        [Route("api/Denuncias/GetComplaints")]
        public HttpResponseMessage GetMaltrato()
        {
            List<DenunciaModelDTO> ListMaltratoModelDTO = new List<DenunciaModelDTO>();
            List<Denuncia> ListDenuncia = new List<Denuncia>();
            ListDenuncia = db.Denuncia.Where(c => c.estado_den.Equals("En tratamiento")).ToList();

            foreach (var i in ListDenuncia)
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
                    Address = i.dir_den,
                    Phone = i.tel_cont,
                    Breed = i.Raza.nom_raza,
                    Photos = listFotoDTO
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListMaltratoModelDTO);
        }

        [Route("api/Denuncias/GetAllComplaints")]
        public HttpResponseMessage GetAllMaltrato()
        {
            List<DenunciaModelDTO> ListMaltratoModelDTO = new List<DenunciaModelDTO>();
            List<Denuncia> ListDenuncia = new List<Denuncia>();
            ListDenuncia = db.Denuncia.ToList();

            foreach (var i in ListDenuncia)
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
                    Address = i.dir_den,
                    Phone = i.tel_cont,
                    Breed = i.Raza.nom_raza,
                    Photos = listFotoDTO
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListMaltratoModelDTO);
        }

        //[Route("api/Denuncias/{userId}/GetComplaintByUser")]
        //public HttpResponseMessage GetCommentByComplaint(int userId)
        //{
        //    List<DenunciaModelDTO> ListMaltratoModelDTO = new List<DenunciaModelDTO>();
        //    List<Denuncia> ListMaltrato = new List<Denuncia>();
        //    ListMaltrato = db.Denuncia.Where(m => m.cod_usu == userId).ToList();

        //    foreach (var i in ListMaltrato)
        //    {
        //        var listFotoDB = db.Foto_Denuncia.Where(x => x.cod_den == i.cod_den).ToList();
        //        List<FotoDenunciaModelDTO> listFotoDTO = new List<FotoDenunciaModelDTO>();
        //        foreach (var item in listFotoDB)
        //        {
        //            listFotoDTO.Add(new FotoDenunciaModelDTO()
        //            {
        //                IdPhoto = item.cod_foto_den,
        //                Photo = item.foto
        //            });
        //        }
        //        ListMaltratoModelDTO.Add(new DenunciaModelDTO()
        //        {
        //            Id = i.cod_den,
        //            Title = i.titulo_den,
        //            Description = i.descrip_den,
        //            Photos = listFotoDTO
        //        });
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, ListMaltratoModelDTO);
        //}

        [Route("api/Denuncias/GetComplaintResolve")]
        public HttpResponseMessage GetComplaintResolve()
        {
            List<DenunciaModelDTO> ListMaltratoModelDTO = new List<DenunciaModelDTO>();
            List<Denuncia> ListMaltrato = new List<Denuncia>();
            ListMaltrato = db.Denuncia.Where(d => d.estado_den == "Solucionada").ToList();

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
                ListMaltratoModelDTO.Add(new DenunciaModelDTO()
                {
                    Id = i.cod_den,
                    Title = i.titulo_den,
                    Description = i.descrip_den,
                    Address=i.dir_den,
                    Phone=i.tel_cont,
                    Breed=i.Raza.nom_raza,
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
        public bool PutMaltrato(int id, EstadoDenunciaModelDTO estadoDenuncia)
        {
            var entity = db.Denuncia.Where(d => d.cod_den == id).FirstOrDefault();
            entity.estado_den = estadoDenuncia.State;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaltratoExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }


        [ResponseType(typeof(Denuncia))]
        public IHttpActionResult PostDenuncia(DenunciaModelPostDTO denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Denuncia.Add(new Denuncia() { titulo_den = denuncia.Title,cod_raza = denuncia.IdBreed,  descrip_den = denuncia.Description, fecha_reg = DateTime.Now, dir_den = denuncia.Address, tel_cont = denuncia.Phone, estado_den="En evaluacion", cod_usu = denuncia.IdUser });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, denuncia);
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