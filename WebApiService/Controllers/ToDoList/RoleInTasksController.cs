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
    public class RoleInTasksController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/RoleInTasks/GetAllDTO")]
        [HttpGet]
        public IQueryable<RoleInTaskDTO> GetAllDTO()
        {
            var roleInTask = db.GetAllRoleInTask();
            var result = roleInTask.AsQueryable().Select(RoleInTaskDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/RoleInTasks/GetByParams")]
        [HttpGet]
        public IQueryable<RoleInTaskDTO> GetByParams(RoleInTaskDTO model)
        {
            var roleInTask = db.GetRoleInTaskByParam(model.ArName,
                                                     model.EnName
                                                    );
            var result = roleInTask.AsQueryable().Select(RoleInTaskDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/RoleInTasks
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/RoleInTasks/GetAll")]
        [HttpGet]
        public IQueryable<RoleInTask> GetAll()
        {
            return db.RoleInTasks;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/RoleInTasks/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(RoleInTask))]
        [Route("api/RoleInTasks/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            RoleInTask roleInTask = await db.RoleInTasks.FindAsync(id);
            if (roleInTask == null)
            {
                return NotFound();
            }

            return Ok(roleInTask);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/RoleInTasks/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/RoleInTasks/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, RoleInTaskDTO roleInTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleInTask.ID)
            {
                return BadRequest();
            }

            RoleInTask TBL = new RoleInTask();
            TBL = roleInTask.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

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
            return Ok(RoleInTaskDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/RoleInTasks
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(RoleInTask))]
        [Route("api/RoleInTasks/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(RoleInTaskDTO roleInTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RoleInTask TBL = new RoleInTask();
            TBL = roleInTask.GetOriginal(TBL);
            db.RoleInTasks.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(RoleInTaskDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/RoleInTasks/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(RoleInTask))]
        [Route("api/RoleInTasks/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
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