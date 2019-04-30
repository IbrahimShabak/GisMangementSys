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
using DAL.Operations.DTO.ToDoList;

namespace WebApiService.Controllers.ToDoList
{
    [MyAuthorize(Roles = "admin")]
    public class EmployeeTasksController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeTasks/GetAllDTO")]
        [HttpGet]
        public IQueryable<EmployeeTaskDTO> GetAllDTO()
        {
            var employeeTask = db.GetAllEmployeeTask();
            var result = employeeTask.AsQueryable().Select(EmployeeTaskDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeTasks/GetByParams")]
        [HttpGet]
        public IQueryable<EmployeeTaskDTO> GetByParams(EmployeeTaskDTO model)
        {
            var employeeTask = db.GetEmployeeTaskByParam(model.TaskID,
                                                                model.EmpID,
                                                                model.RoleInTask
                                                                );
            var result = employeeTask.AsQueryable().Select(EmployeeTaskDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EmployeeTasks
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeTasks/GetAll")]
        [HttpGet]
        public IQueryable<EmployeeTask> GetEmployeeTasks()
        {
            return db.EmployeeTasks;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EmployeeTasks/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeTask))]
        [Route("api/EmployeeTasks/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            EmployeeTask employeeTask = await db.EmployeeTasks.FindAsync(id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            return Ok(employeeTask);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/EmployeeTasks/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/EmployeeTasks/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, EmployeeTaskDTO employeeTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeTask.ID)
            {
                return BadRequest();
            }

            EmployeeTask TBL = new EmployeeTask();
            TBL = employeeTask.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

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
            return Ok(EmployeeTaskDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/EmployeeTasks
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeTask))]
        [Route("api/EmployeeTasks/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(EmployeeTaskDTO employeeTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeTask TBL = new EmployeeTask();
            TBL = employeeTask.GetOriginal(TBL);
            db.EmployeeTasks.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(EmployeeTaskDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/EmployeeTasks/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeTask))]
        [Route("api/EmployeeTasks/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
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