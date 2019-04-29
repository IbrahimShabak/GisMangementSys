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
    public class TaskTypesController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();

        // GET: api/TaskTypes
        public IQueryable<TaskType> GetTaskTypes()
        {
            return db.TaskTypes;
        }

        // GET: api/TaskTypes/5
        [ResponseType(typeof(TaskType))]
        public async Task<IHttpActionResult> GetTaskType(int id)
        {
            TaskType taskType = await db.TaskTypes.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }

            return Ok(taskType);
        }

        // PUT: api/TaskTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTaskType(int id, TaskType taskType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskType.ID)
            {
                return BadRequest();
            }

            db.Entry(taskType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTypeExists(id))
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

        // POST: api/TaskTypes
        [ResponseType(typeof(TaskType))]
        public async Task<IHttpActionResult> PostTaskType(TaskType taskType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskTypes.Add(taskType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = taskType.ID }, taskType);
        }

        // DELETE: api/TaskTypes/5
        [ResponseType(typeof(TaskType))]
        public async Task<IHttpActionResult> DeleteTaskType(int id)
        {
            TaskType taskType = await db.TaskTypes.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }

            db.TaskTypes.Remove(taskType);
            await db.SaveChangesAsync();

            return Ok(taskType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskTypeExists(int id)
        {
            return db.TaskTypes.Count(e => e.ID == id) > 0;
        }
    }
}