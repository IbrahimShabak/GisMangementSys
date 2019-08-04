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
    public class TaskTypesController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/TaskTypes/GetAllDTO")]
        [HttpGet]
        public IQueryable<TaskTypeDTO> GetAllDTO()
        {
            var taskType = db.GetAllTaskType();
            var result = taskType.AsQueryable().Select(TaskTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/TaskTypes/GetByParams")]
        [HttpGet]
        public IQueryable<TaskTypeDTO> GetByParams(TaskTypeDTO model)
        {
            var taskType = db.GetTaskTypeByParam( model.ArName,
                                                     model.EnName
                                                                );
            var result = taskType.AsQueryable().Select(TaskTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/TaskTypes
        [MyAuthorize(Roles = "admin")]
        [Route("api/TaskTypes/GetAll")]
        [HttpGet]
        public IQueryable<TaskType> GetAll()
        {
            return db.TaskTypes;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/TaskTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(TaskType))]
        [Route("api/TaskTypes/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            TaskType taskType = await db.TaskTypes.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }

            return Ok(taskType);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/TaskTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [Route("api/TaskTypes/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, TaskTypeDTO taskType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskType.ID)
            {
                return BadRequest();
            }

            TaskType TBL = new TaskType();
            TBL = taskType.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

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
            return Ok(TaskTypeDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/TaskTypes
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(TaskType))]
        [Route("api/TaskTypes/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(TaskTypeDTO taskType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TaskType TBL = new TaskType();
            TBL = taskType.GetOriginal(TBL);
            db.TaskTypes.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(TaskTypeDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/TaskTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(TaskType))]
        [Route("api/TaskTypes/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
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