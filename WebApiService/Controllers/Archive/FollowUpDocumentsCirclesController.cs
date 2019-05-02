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
    public class FollowUpDocumentsCirclesController : ApiController
    {
        private ArchiveDBEntities db = new ArchiveDBEntities();

        // GET: api/FollowUpDocumentsCircles
        public IQueryable<FollowUpDocumentsCircle> GetFollowUpDocumentsCircles()
        {
            return db.FollowUpDocumentsCircles;
        }

        // GET: api/FollowUpDocumentsCircles/5
        [ResponseType(typeof(FollowUpDocumentsCircle))]
        public async Task<IHttpActionResult> GetFollowUpDocumentsCircle(int id)
        {
            FollowUpDocumentsCircle followUpDocumentsCircle = await db.FollowUpDocumentsCircles.FindAsync(id);
            if (followUpDocumentsCircle == null)
            {
                return NotFound();
            }

            return Ok(followUpDocumentsCircle);
        }

        // PUT: api/FollowUpDocumentsCircles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFollowUpDocumentsCircle(int id, FollowUpDocumentsCircle followUpDocumentsCircle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != followUpDocumentsCircle.ArchiveID)
            {
                return BadRequest();
            }

            db.Entry(followUpDocumentsCircle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowUpDocumentsCircleExists(id))
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

        // POST: api/FollowUpDocumentsCircles
        [ResponseType(typeof(FollowUpDocumentsCircle))]
        public async Task<IHttpActionResult> PostFollowUpDocumentsCircle(FollowUpDocumentsCircle followUpDocumentsCircle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FollowUpDocumentsCircles.Add(followUpDocumentsCircle);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FollowUpDocumentsCircleExists(followUpDocumentsCircle.ArchiveID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = followUpDocumentsCircle.ArchiveID }, followUpDocumentsCircle);
        }

        // DELETE: api/FollowUpDocumentsCircles/5
        [ResponseType(typeof(FollowUpDocumentsCircle))]
        public async Task<IHttpActionResult> DeleteFollowUpDocumentsCircle(int id)
        {
            FollowUpDocumentsCircle followUpDocumentsCircle = await db.FollowUpDocumentsCircles.FindAsync(id);
            if (followUpDocumentsCircle == null)
            {
                return NotFound();
            }

            db.FollowUpDocumentsCircles.Remove(followUpDocumentsCircle);
            await db.SaveChangesAsync();

            return Ok(followUpDocumentsCircle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FollowUpDocumentsCircleExists(int id)
        {
            return db.FollowUpDocumentsCircles.Count(e => e.ArchiveID == id) > 0;
        }
    }
}