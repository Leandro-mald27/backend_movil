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
using APIPROYECTO2.Models;

namespace APIPROYECTO2.Controllers
{
    public class SERVICIOSController : ApiController
    {
        private ProyectoMovilEntities db = new ProyectoMovilEntities();

        // GET: api/SERVICIOS
        public IQueryable<SERVICIOS> GetSERVICIOS()
        {
            return db.SERVICIOS;
        }

        // GET: api/SERVICIOS/5
        [ResponseType(typeof(SERVICIOS))]
        public IHttpActionResult GetSERVICIOS(string id)
        {
            SERVICIOS sERVICIOS = db.SERVICIOS.Find(id);
            if (sERVICIOS == null)
            {
                return NotFound();
            }

            return Ok(sERVICIOS);
        }

        // PUT: api/SERVICIOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSERVICIOS(string id, SERVICIOS sERVICIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sERVICIOS.idServicio)
            {
                return BadRequest();
            }

            db.Entry(sERVICIOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SERVICIOSExists(id))
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

        // POST: api/SERVICIOS
        [ResponseType(typeof(SERVICIOS))]
        public IHttpActionResult PostSERVICIOS(SERVICIOS sERVICIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SERVICIOS.Add(sERVICIOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SERVICIOSExists(sERVICIOS.idServicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sERVICIOS.idServicio }, sERVICIOS);
        }

        // DELETE: api/SERVICIOS/5
        [ResponseType(typeof(SERVICIOS))]
        public IHttpActionResult DeleteSERVICIOS(string id)
        {
            SERVICIOS sERVICIOS = db.SERVICIOS.Find(id);
            if (sERVICIOS == null)
            {
                return NotFound();
            }

            db.SERVICIOS.Remove(sERVICIOS);
            db.SaveChanges();

            return Ok(sERVICIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SERVICIOSExists(string id)
        {
            return db.SERVICIOS.Count(e => e.idServicio == id) > 0;
        }
    }
}