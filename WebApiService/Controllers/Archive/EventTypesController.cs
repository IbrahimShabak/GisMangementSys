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
    public class EventTypesController : ApiController
    {
        private ArchiveDBEntities db = new ArchiveDBEntities();

        // GET: api/EventTypes
        public IQueryable<EventType> GetEventTypes()
        {
            return db.EventTypes;
        }

        // GET: api/EventTypes/5
        [ResponseType(typeof(EventType))]
        public async Task<IHttpActionResult> GetEventType(int id)
        {
            EventType eventType = await db.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            return Ok(eventType);
        }

        // PUT: api/EventTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventType(int id, EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventType.ID)
            {
                return BadRequest();
            }

            db.Entry(eventType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
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

        // POST: api/EventTypes
        [ResponseType(typeof(EventType))]
        public async Task<IHttpActionResult> PostEventType(EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventTypes.Add(eventType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventTypeExists(eventType.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eventType.ID }, eventType);
        }

        // DELETE: api/EventTypes/5
        [ResponseType(typeof(EventType))]
        public async Task<IHttpActionResult> DeleteEventType(int id)
        {
            EventType eventType = await db.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            db.EventTypes.Remove(eventType);
            await db.SaveChangesAsync();

            return Ok(eventType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventTypeExists(int id)
        {
            return db.EventTypes.Count(e => e.ID == id) > 0;
        }
    }
}