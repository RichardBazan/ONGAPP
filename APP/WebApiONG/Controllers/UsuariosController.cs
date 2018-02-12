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
    public class UsuariosController : ApiController
    {
        private BDONGEntities db = new BDONGEntities();

        // GET: api/Usuarios
        [Route("api/Usuarios/Username/{username}/Password/{password}")]
        public HttpResponseMessage GetUsuarioLogin(string username, string password)
        {
            Usuario usuario = new Usuario();
            UsuarioInfoModelDTO UsuarioInfoModelDTO = new UsuarioInfoModelDTO();
            usuario = db.Usuario.Where(x => x.usuario1 == username && x.contraseña == password).FirstOrDefault();
            if (usuario != null)
            {
                UsuarioInfoModelDTO.Id = usuario.cod_usu;
                UsuarioInfoModelDTO.Name = usuario.nom_usu;
                UsuarioInfoModelDTO.FirstLastName = usuario.ape_pat;
                UsuarioInfoModelDTO.SecondLastName = usuario.ape_mat;
                UsuarioInfoModelDTO.Address = usuario.dir_usu;
                UsuarioInfoModelDTO.Phone = usuario.tel_usu;
                UsuarioInfoModelDTO.Birthdate = (DateTime)usuario.fecha_nac;
                UsuarioInfoModelDTO.UserName = usuario.usuario1;
                UsuarioInfoModelDTO.Password = usuario.contraseña;
                UsuarioInfoModelDTO.Photo = usuario.foto_usu;
            }
            else
            {
                var message = string.Format("Usuario o contraseña incorrecto");

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, UsuarioInfoModelDTO);
        }



        // PUT: api/Usuarios/5
        [Route("api/Usuarios/{id}/UpdateUsuario")]
        public bool PutUsuario(int id, UsuarioModelUpdateDTO usuario)
        {
            var entity = db.Usuario.Where(m => m.cod_usu == id).FirstOrDefault();
            entity.nom_usu = usuario.Name;
            entity.ape_pat = usuario.FirstLastName;
            entity.ape_mat = usuario.SecondLastName;
            entity.dir_usu = usuario.Address;
            entity.tel_usu = usuario.Phone;
            entity.fecha_nac = usuario.Birthdate;
            entity.usuario1 = usuario.UserName;
            entity.foto_usu = usuario.Photo;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // PUT: api/Usuarios/5
        [Route("api/Usuarios/{id}/UpdatePassword")]
        public bool PutUsuarioContraseña(int id, CambiarContraseñaModelDTO cambio)
        {
            var entity = db.Usuario.Where(m => m.cod_usu == id).FirstOrDefault();
            if(entity.contraseña == cambio.PasswordActual)
            {
                entity.contraseña = cambio.PasswordNew;
            }
            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public HttpResponseMessage PostUsuario(UsuarioModelDTO usuario)
        {
            Usuario usu = new Usuario();
            usu = db.Usuario.Where(x => x.usuario1 == usuario.UserName).FirstOrDefault();
            if (usu == null)
            {
                db.Usuario.Add(new Usuario() { nom_usu = usuario.Name, ape_pat = usuario.FirstLastName, ape_mat = usuario.SecondLastName, dir_usu = usuario.Address, tel_usu = usuario.Phone, usuario1 = usuario.UserName, fecha_nac = usuario.Birthdate, contraseña = usuario.Password, foto_usu = usuario.Photo });
                db.SaveChanges();
            }
            else
            {
                var message = string.Format("El nombre de usuario ya esta en uso");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }


            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.cod_usu == id) > 0;
        }
    }
}