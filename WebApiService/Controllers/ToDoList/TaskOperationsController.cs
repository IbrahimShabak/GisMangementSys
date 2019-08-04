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
    public class TaskOperationsController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/TaskOperations/GetAllDTO")]
        [HttpGet]
        public IQueryable<TaskOperationDTO> GetAllDTO()
        {
            var taskOperation = db.GetAllTaskOperations();
            var result = taskOperation.AsQueryable().Select(TaskOperationDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/TaskOperations/GetByParams")]
        [HttpGet]
        public IQueryable<TaskOperationDTO> GetByParams(TaskOperationDTO model)
        {
            var taskOperation = db.GetTaskOperationsByParam(model.TaskID,
                                                                model.TaskName,
                                                                model.CreatorEmp,
                                                                model.ParentID,
                                                                model.DeliverableID,
                                                                model.TaskStatus,
                                                                model.TaskType,
                                                                model.TaskProierty
                                                                );
            var result = taskOperation.AsQueryable().Select(TaskOperationDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/TaskOperations/GetByLike")]
        [HttpGet]
        public IQueryable<TaskOperationDTO> GetByLike(TaskOperationDTO model)
        {
            var taskOperation = db.GetLikeTaskOperations(model.TaskName
                                                       );
            var result = taskOperation.AsQueryable().Select(TaskOperationDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/TaskOperations
        [MyAuthorize(Roles = "admin")]
        [Route("api/TaskOperations/GetAll")]
        [HttpGet]
        public IQueryable<TaskOperation> GetAll()
        {
            return db.TaskOperations;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/TaskOperations/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(TaskOperation))]
        [Route("api/TaskOperations/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            TaskOperation taskOperation = await db.TaskOperations.FindAsync(id);
            if (taskOperation == null)
            {
                return NotFound();
            }

            return Ok(taskOperation);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/TaskOperations/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [Route("api/TaskOperations/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, TaskOperationDTO taskOperation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskOperation.TaskID)
            {
                return BadRequest();
            }

            TaskOperation TBL = new TaskOperation();
            TBL = taskOperation.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

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
            return Ok(TaskOperationDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/TaskOperations
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(TaskOperation))]
        [Route("api/TaskOperations/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(TaskOperationDTO taskOperation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TaskOperation TBL = new TaskOperation();
            TBL = taskOperation.GetOriginal(TBL);
            db.TaskOperations.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(TaskOperationDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/TaskOperations/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(TaskOperation))]
        [Route("api/TaskOperations/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
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