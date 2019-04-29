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
    public class RoleInTasksController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();

        // GET: api/RoleInTasks
        public IQueryable<RoleInTask> GetRoleInTasks()
        {
            return db.RoleInTasks;
        }

        // GET: api/RoleInTasks/5
        [ResponseType(typeof(RoleInTask))]
        public async Task<IHttpActionResult> GetRoleInTask(int id)
        {
            RoleInTask roleInTask = await db.RoleInTasks.FindAsync(id);
            if (roleInTask == null)
            {
                return NotFound();
            }

            return Ok(roleInTask);
        }

        // PUT: api/RoleInTasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRoleInTask(int id, RoleInTask roleInTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleInTask.ID)
            {
                return BadRequest();
            }

            db.Entry(roleInTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleInTaskExists(id))
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

        // POST: api/RoleInTasks
        [ResponseType(typeof(RoleInTask))]
        public async Task<IHttpActionResult> PostRoleInTask(RoleInTask roleInTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoleInTasks.Add(roleInTask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = roleInTask.ID }, roleInTask);
        }

        // DELETE: api/RoleInTasks/5
        [ResponseType(typeof(RoleInTask))]
        public async Task<IHttpActionResult> DeleteRoleInTask(int id)
        {
            RoleInTask roleInTask = await db.RoleInTasks.FindAsync(id);
            if (roleInTask == null)
            {
                return NotFound();
            }

            db.RoleInTasks.Remove(roleInTask);
            await db.SaveChangesAsync();

            return Ok(roleInTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleInTaskExists(int id)
        {
            return db.RoleInTasks.Count(e => e.ID == id) > 0;
        }
    }
}