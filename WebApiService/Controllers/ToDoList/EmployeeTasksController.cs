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
    public class EmployeeTasksController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();

        // GET: api/EmployeeTasks
        public IQueryable<EmployeeTask> GetEmployeeTasks()
        {
            return db.EmployeeTasks;
        }

        // GET: api/EmployeeTasks/5
        [ResponseType(typeof(EmployeeTask))]
        public async Task<IHttpActionResult> GetEmployeeTask(int id)
        {
            EmployeeTask employeeTask = await db.EmployeeTasks.FindAsync(id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            return Ok(employeeTask);
        }

        // PUT: api/EmployeeTasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeTask(int id, EmployeeTask employeeTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeTask.ID)
            {
                return BadRequest();
            }

            db.Entry(employeeTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTaskExists(id))
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

        // POST: api/EmployeeTasks
        [ResponseType(typeof(EmployeeTask))]
        public async Task<IHttpActionResult> PostEmployeeTask(EmployeeTask employeeTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeTasks.Add(employeeTask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employeeTask.ID }, employeeTask);
        }

        // DELETE: api/EmployeeTasks/5
        [ResponseType(typeof(EmployeeTask))]
        public async Task<IHttpActionResult> DeleteEmployeeTask(int id)
        {
            EmployeeTask employeeTask = await db.EmployeeTasks.FindAsync(id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            db.EmployeeTasks.Remove(employeeTask);
            await db.SaveChangesAsync();

            return Ok(employeeTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeTaskExists(int id)
        {
            return db.EmployeeTasks.Count(e => e.ID == id) > 0;
        }
    }
}