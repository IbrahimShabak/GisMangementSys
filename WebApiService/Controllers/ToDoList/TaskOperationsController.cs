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
    public class TaskOperationsController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();

        // GET: api/TaskOperations
        public IQueryable<TaskOperation> GetTaskOperations()
        {
            return db.TaskOperations;
        }

        // GET: api/TaskOperations/5
        [ResponseType(typeof(TaskOperation))]
        public async Task<IHttpActionResult> GetTaskOperation(int id)
        {
            TaskOperation taskOperation = await db.TaskOperations.FindAsync(id);
            if (taskOperation == null)
            {
                return NotFound();
            }

            return Ok(taskOperation);
        }

        // PUT: api/TaskOperations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTaskOperation(int id, TaskOperation taskOperation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskOperation.TaskID)
            {
                return BadRequest();
            }

            db.Entry(taskOperation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskOperationExists(id))
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

        // POST: api/TaskOperations
        [ResponseType(typeof(TaskOperation))]
        public async Task<IHttpActionResult> PostTaskOperation(TaskOperation taskOperation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskOperations.Add(taskOperation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = taskOperation.TaskID }, taskOperation);
        }

        // DELETE: api/TaskOperations/5
        [ResponseType(typeof(TaskOperation))]
        public async Task<IHttpActionResult> DeleteTaskOperation(int id)
        {
            TaskOperation taskOperation = await db.TaskOperations.FindAsync(id);
            if (taskOperation == null)
            {
                return NotFound();
            }

            db.TaskOperations.Remove(taskOperation);
            await db.SaveChangesAsync();

            return Ok(taskOperation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskOperationExists(int id)
        {
            return db.TaskOperations.Count(e => e.TaskID == id) > 0;
        }
    }
}