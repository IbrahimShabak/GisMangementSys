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
    public class ActionTypesController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/ActionTypes/GetAllDTO")]
        [HttpGet]
        public IQueryable<ActionTypeDTO> GetAllDTO()
        {
            var actionType = db.GetAllActionType();
            var result = actionType.AsQueryable().Select(ActionTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/ActionTypes/GetByParams")]
        [HttpGet]
        public IQueryable<ActionTypeDTO> GetByParams(ActionTypeDTO model)
        {
            var actionType = db.GetActionTypeByParam(model.ArName,
                                                                model.EnName
                                                                );
            var result = actionType.AsQueryable().Select(ActionTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ActionTypes
        [MyAuthorize(Roles = "admin")]
        [Route("api/ActionTypes/GetAll")]
        [HttpGet]
        public IQueryable<ActionType> GetActionTypes()
        {
            return db.ActionTypes;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ActionTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(ActionType))]
        [Route("api/ActionTypes/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetActionType(int id)
        {
            ActionType actionType = await db.ActionTypes.FindAsync(id);
            if (actionType == null)
            {
                return NotFound();
            }

            return Ok(actionType);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/ActionTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [Route("api/ActionTypes/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, ActionTypeDTO actionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actionType.ID)
            {
                return BadRequest();
            }

            ActionType TBL = new ActionType();
            TBL = actionType.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

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
            return Ok(ActionTypeDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/ActionTypes
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(ActionType))]
        [Route("api/ActionTypes/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(ActionTypeDTO actionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ActionType TBL = new ActionType();
            TBL = actionType.GetOriginal(TBL);
            db.ActionTypes.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(ActionTypeDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/ActionTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(ActionType))]
        [Route("api/ActionTypes/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
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