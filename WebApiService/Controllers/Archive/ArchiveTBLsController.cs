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
using DAL.Entities.Archive;

namespace WebApiService.Controllers.Archive
{
    public class ArchiveTBLsController : ApiController
    {
        private ArchiveDBEntities db = new ArchiveDBEntities();

        // GET: api/ArchiveTBLs
        public IQueryable<ArchiveTBL> GetArchiveTBLs()
        {
            return db.ArchiveTBLs;
        }

        // GET: api/ArchiveTBLs/5
        [ResponseType(typeof(ArchiveTBL))]
        public async Task<IHttpActionResult> GetArchiveTBL(int id)
        {
            ArchiveTBL archiveTBL = await db.ArchiveTBLs.FindAsync(id);
            if (archiveTBL == null)
            {
                return NotFound();
            }

            return Ok(archiveTBL);
        }

        // PUT: api/ArchiveTBLs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArchiveTBL(int id, ArchiveTBL archiveTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archiveTBL.ID)
            {
                return BadRequest();
            }

            db.Entry(archiveTBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveTBLExists(id))
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

        // POST: api/ArchiveTBLs
        [ResponseType(typeof(ArchiveTBL))]
        public async Task<IHttpActionResult> PostArchiveTBL(ArchiveTBL archiveTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArchiveTBLs.Add(archiveTBL);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArchiveTBLExists(archiveTBL.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = archiveTBL.ID }, archiveTBL);
        }

        // DELETE: api/ArchiveTBLs/5
        [ResponseType(typeof(ArchiveTBL))]
        public async Task<IHttpActionResult> DeleteArchiveTBL(int id)
        {
            ArchiveTBL archiveTBL = await db.ArchiveTBLs.FindAsync(id);
            if (archiveTBL == null)
            {
                return NotFound();
            }

            db.ArchiveTBLs.Remove(archiveTBL);
            await db.SaveChangesAsync();

            return Ok(archiveTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArchiveTBLExists(int id)
        {
            return db.ArchiveTBLs.Count(e => e.ID == id) > 0;
        }
    }
}