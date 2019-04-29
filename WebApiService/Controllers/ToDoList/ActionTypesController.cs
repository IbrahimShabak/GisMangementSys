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
    public class ActionTypesController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();

        // GET: api/ActionTypes
        public IQueryable<ActionType> GetActionTypes()
        {
            return db.ActionTypes;
        }

        // GET: api/ActionTypes/5
        [ResponseType(typeof(ActionType))]
        public async Task<IHttpActionResult> GetActionType(int id)
        {
            ActionType actionType = await db.ActionTypes.FindAsync(id);
            if (actionType == null)
            {
                return NotFound();
            }

            return Ok(actionType);
        }

        // PUT: api/ActionTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActionType(int id, ActionType actionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actionType.ID)
            {
                return BadRequest();
            }

            db.Entry(actionType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionTypeExists(id))
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

        // POST: api/ActionTypes
        [ResponseType(typeof(ActionType))]
        public async Task<IHttpActionResult> PostActionType(ActionType actionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActionTypes.Add(actionType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = actionType.ID }, actionType);
        }

        // DELETE: api/ActionTypes/5
        [ResponseType(typeof(ActionType))]
        public async Task<IHttpActionResult> DeleteActionType(int id)
        {
            ActionType actionType = await db.ActionTypes.FindAsync(id);
            if (actionType == null)
            {
                return NotFound();
            }

            db.ActionTypes.Remove(actionType);
            await db.SaveChangesAsync();

            return Ok(actionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActionTypeExists(int id)
        {
            return db.ActionTypes.Count(e => e.ID == id) > 0;
        }
    }
}