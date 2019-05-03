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
using DAL.Operations.DTO.Archive;

namespace WebApiService.Controllers.Archive
{
    [MyAuthorize(Roles = "admin")]
    public class EventTypesController : ApiController
    {
        private ArchiveDBEntities db = new ArchiveDBEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EventTypes/GetAllDTO")]
        [HttpGet]
        public IQueryable<EventTypeDTO> GetAllDTO()
        {
            var archiveTBL = db.GetAllEventType();
            var result = archiveTBL.AsQueryable().Select(EventTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EventTypes
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EventTypes/GetAll")]
        [HttpGet]
        public IQueryable<EventType> GetAll()
        {
            return db.EventTypes;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EventTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EventType))]
        [Route("api/EventTypes/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            EventType eventType = await db.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            return Ok(eventType);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/EventTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/EventTypes/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, EventTypeDTO eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventType.ID)
            {
                return BadRequest();
            }

            EventType TBL = new EventType();
            TBL = eventType.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

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
            return Ok(EventTypeDTO.GetDTO(TBL));
            //return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/EventTypes
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EventType))]
        [Route("api/EventTypes/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(EventTypeDTO eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EventType TBL = new EventType();
            TBL = eventType.GetOriginal(TBL);
            db.EventTypes.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(EventTypeDTO.GetDTO(TBL));
            //return Ok(ArchiveTBLDTO.GetDTO(TBL));

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (EventTypeExists(eventType.ID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = eventType.ID }, eventType);
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/EventTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EventType))]
        [Route("api/EventTypes/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
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