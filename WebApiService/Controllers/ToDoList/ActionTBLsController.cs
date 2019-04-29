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
    public class ActionTBLsController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ActionTBLs/GetAllDTO")]
        [HttpGet]
        public IQueryable<ActionTBLDTO> GetAllDTO()
        {
            var actionTBL = db.GetAllActionTBL();
            var result = actionTBL.AsQueryable().Select(ActionTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ActionTBLs/GetByParams")]
        [HttpGet]
        public IQueryable<ActionTBLDTO> GetByParams(ActionTBLDTO model)
        {
            var actionTBL = db.GetActionTBLByParam(model.EmployeeActionID,
                                                                model.ActionTaken                                                                
                                                                );
            var result = actionTBL.AsQueryable().Select(ActionTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ActionTBLs
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ActionTBLs/GetAll")]
        [HttpGet]
        public IQueryable<ActionTBL> GetAll()
        {
            return db.ActionTBLs;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ActionTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ActionTBL))]
        [Route("api/ActionTBLs/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            ActionTBL actionTBL = await db.ActionTBLs.FindAsync(id);
            if (actionTBL == null)
            {
                return NotFound();
            }

            return Ok(actionTBL);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/ActionTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/ActionTBLs/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, ActionTBLDTO actionTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actionTBL.ID)
            {
                return BadRequest();
            }

            ActionTBL TBL = new ActionTBL();
            TBL = actionTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(ActionTBLDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/ActionTBLs
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ActionTBL))]
        [Route("api/ActionTBLs/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddNew(ActionTBLDTO actionTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ActionTBL TBL = new ActionTBL();
            TBL = actionTBL.GetOriginal(TBL);
            db.ActionTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(ActionTBLDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/ActionTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ActionTBL))]
        [Route("api/ActionTBLs/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            ActionTBL actionTBL = await db.ActionTBLs.FindAsync(id);
            if (actionTBL == null)
            {
                return NotFound();
            }

            db.ActionTBLs.Remove(actionTBL);
            await db.SaveChangesAsync();

            return Ok(actionTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActionTBLExists(int id)
        {
            return db.ActionTBLs.Count(e => e.ID == id) > 0;
        }
    }
}