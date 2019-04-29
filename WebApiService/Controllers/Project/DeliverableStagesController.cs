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
using DAL.Entities.Projects;
using DAL.Operations.DTO.Project;

namespace WebApiService.Controllers
{
    [MyAuthorize(Roles = "admin")]
    public class DeliverableStagesController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DeliverableStages/GetAllS")]
        [HttpGet]
        public IQueryable<DeliverableStageDTO> GetAllDeliverableStages()
        {
            var DeliverableStages = db.SelectAllDeliverableStage();
            var result = DeliverableStages.AsQueryable().Select(DeliverableStageDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DeliverableStages/GetByParam")]
        [HttpGet]
        public IQueryable<DeliverableStageDTO> SelectParamDeliverableStages(DeliverableStageDTO model)
        {
            var deliverableStages = db.SelectParamDeliverableStage(model.DeliverableID,
                                                                model.StageID,
                                                                model.DeliverableArName,
                                                                model.DeliverableEnName
                                                                );
            var result = deliverableStages.AsQueryable().Select(DeliverableStageDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DeliverableStages/GetByLike")]
        [HttpGet]
        public IQueryable<DeliverableStageDTO> SelectlikeDeliverableStage(DeliverableStageDTO model)
        {
            var DeliverableStages = db.SelectlikeDeliverableStage(model.DeliverableArName,
                                                                  model.DeliverableEnName
                                                                   );
            var result = DeliverableStages.AsQueryable().Select(DeliverableStageDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/DeliverableStages
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DeliverableStages/GetAll")]
        [HttpGet]
        public IQueryable<DeliverableStage> GetDeliverableStages()
        {
            return db.DeliverableStages;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/DeliverableStages/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DeliverableStage))]
        [Route("api/DeliverableStages/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDeliverableStage(int id)
        {
            DeliverableStage deliverableStage = await db.DeliverableStages.FindAsync(id);
            if (deliverableStage == null)
            {
                return NotFound();
            }

            return Ok(deliverableStage);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/DeliverableStages/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/DeliverableStages/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutDeliverableStage(int id, DeliverableStageDTO deliverableStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliverableStage.DeliverableID)
            {
                return BadRequest();
            }

            DeliverableStage TBL = new DeliverableStage();
            TBL = deliverableStage.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliverableStageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(DeliverableStageDTO.GetDTO(TBL));
            //return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/DeliverableStages
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DeliverableStage))]
        [Route("api/DeliverableStages/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostDeliverableStage(DeliverableStageDTO deliverableStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DeliverableStage TBL = new DeliverableStage();
            TBL = deliverableStage.GetOriginal(TBL);
            db.DeliverableStages.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(DeliverableStageDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/DeliverableStages/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DeliverableStage))]
        [Route("api/DeliverableStages/Delete/{ID:int}")]
        [HttpDelete] 
        public async Task<IHttpActionResult> DeleteDeliverableStage(int id)
        {
            DeliverableStage deliverableStage = await db.DeliverableStages.FindAsync(id);
            if (deliverableStage == null)
            {
                return NotFound();
            }

            db.DeliverableStages.Remove(deliverableStage);
            await db.SaveChangesAsync();

            return Ok(deliverableStage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliverableStageExists(int id)
        {
            return db.DeliverableStages.Count(e => e.DeliverableID == id) > 0;
        }
    }
}