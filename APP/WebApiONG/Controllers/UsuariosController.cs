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
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuario;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.cod_usu)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(UsuarioModelDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuario.Add(new Usuario() { nom_usu=usuario.Name,ape_pat=usuario.FirstLastName,ape_mat=usuario.SecondLastName,dir_usu=usuario.Address,tel_usu=usuario.Phone,usuario1=usuario.UserName, fecha_nac=usuario.Birthdate,contraseña=usuario.Password });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                e.GetBaseException();
            }

            return CreatedAtRoute("DefaultApi", null, usuario);
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