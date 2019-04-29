using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DAL.Entities.ToDoList;

namespace WebApiService.Controllers.ToDoList
{
    [MyAuthorize(Roles = "admin")]
    public class ProiertyTypesController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();

        // GET: api/ProiertyTypes
        public IQueryable<ProiertyType> GetProiertyTypes()
        {
            return db.ProiertyTypes;
        }

        // GET: api/ProiertyTypes/5
        [ResponseType(typeof(ProiertyType))]
        public async Task<IHttpActionResult> GetProiertyType(int id)
        {
            ProiertyType proiertyType = await db.ProiertyTypes.FindAsync(id);
            if (proiertyType == null)
            {
                return NotFound();
            }

            return Ok(proiertyType);
        }

        // PUT: api/ProiertyTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProiertyType(int id, ProiertyType proiertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proiertyType.ID)
            {
                return BadRequest();
            }

            db.Entry(proiertyType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProiertyTypeExists(id))
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

        // POST: api/ProiertyTypes
        [ResponseType(typeof(ProiertyType))]
        public async Task<IHttpActionResult> PostProiertyType(ProiertyType proiertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProiertyTypes.Add(proiertyType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = proiertyType.ID }, proiertyType);
        }

        // DELETE: api/ProiertyTypes/5
        [ResponseType(typeof(ProiertyType))]
        public async Task<IHttpActionResult> DeleteProiertyType(int id)
        {
            ProiertyType proiertyType = await db.ProiertyTypes.FindAsync(id);
            if (proiertyType == null)
            {
                return NotFound();
            }

            db.ProiertyTypes.Remove(proiertyType);
            await db.SaveChangesAsync();

            return Ok(proiertyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProiertyTypeExists(int id)
        {
            return db.ProiertyTypes.Count(e => e.ID == id) > 0;
        }
    }
}