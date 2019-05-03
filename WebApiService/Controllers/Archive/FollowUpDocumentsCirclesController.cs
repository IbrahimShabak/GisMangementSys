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
using DAL.Entities.Archive;
using DAL.Operations.DTO.Archive;

namespace WebApiService.Controllers.Archive
{
    [MyAuthorize(Roles = "admin")]
    public class FollowUpDocumentsCirclesController : ApiController
    {
        private ArchiveDBEntities db = new ArchiveDBEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/FollowUpDocumentsCircles/GetAllDTO")]
        [HttpGet]
        public IQueryable<FollowUpDocumentsCircleDTO> GetAllDTO()
        {
            var followUpDocumentsCircle = db.GetAllFollowUpDocumentsCircle();
            var result = followUpDocumentsCircle.AsQueryable().Select(FollowUpDocumentsCircleDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/FollowUpDocumentsCircles/GetByParams")]
        [HttpGet]
        public IQueryable<FollowUpDocumentsCircleDTO> GetByParams(FollowUpDocumentsCircleDTO model)
        {
            var followUpDocumentsCircle = db.GetFollowUpDocumentsCircleByParam(model.ArchiveID,
                                                                model.EmpID,
                                                                model.EventType
                                                                );
            var result = followUpDocumentsCircle.AsQueryable().Select(FollowUpDocumentsCircleDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/FollowUpDocumentsCircles
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/FollowUpDocumentsCircles/GetAll")]
        [HttpGet]
        public IQueryable<FollowUpDocumentsCircle> GetAll()
        {
            return db.FollowUpDocumentsCircles;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/FollowUpDocumentsCircles/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(FollowUpDocumentsCircle))]
        [Route("api/FollowUpDocumentsCircles/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            FollowUpDocumentsCircle followUpDocumentsCircle = await db.FollowUpDocumentsCircles.FindAsync(id);
            if (followUpDocumentsCircle == null)
            {
                return NotFound();
            }

            return Ok(followUpDocumentsCircle);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/FollowUpDocumentsCircles/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/FollowUpDocumentsCircles/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, FollowUpDocumentsCircleDTO followUpDocumentsCircle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != followUpDocumentsCircle.ArchiveID)
            {
                return BadRequest();
            }

            FollowUpDocumentsCircle TBL = new FollowUpDocumentsCircle();
            TBL = followUpDocumentsCircle.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowUpDocumentsCircleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(FollowUpDocumentsCircleDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/FollowUpDocumentsCircles
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(FollowUpDocumentsCircle))]
        [Route("api/FollowUpDocumentsCircles/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(FollowUpDocumentsCircleDTO followUpDocumentsCircle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FollowUpDocumentsCircle TBL = new FollowUpDocumentsCircle();
            TBL = followUpDocumentsCircle.GetOriginal(TBL);
            db.FollowUpDocumentsCircles.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(FollowUpDocumentsCircleDTO.GetDTO(TBL));

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (FollowUpDocumentsCircleExists(followUpDocumentsCircle.ArchiveID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = followUpDocumentsCircle.ArchiveID }, followUpDocumentsCircle);
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/FollowUpDocumentsCircles/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(FollowUpDocumentsCircle))]
        [Route("api/FollowUpDocumentsCircles/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            FollowUpDocumentsCircle followUpDocumentsCircle = await db.FollowUpDocumentsCircles.FindAsync(id);
            if (followUpDocumentsCircle == null)
            {
                return NotFound();
            }

            db.FollowUpDocumentsCircles.Remove(followUpDocumentsCircle);
            await db.SaveChangesAsync();

            return Ok(followUpDocumentsCircle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FollowUpDocumentsCircleExists(int id)
        {
            return db.FollowUpDocumentsCircles.Count(e => e.ArchiveID == id) > 0;
        }
    }
}