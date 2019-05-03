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
    public class ArchiveTBLsController : ApiController
    {
       
        private ArchiveDBEntities db = new ArchiveDBEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ArchiveTBLs/GetAllDTO")]
        [HttpGet]
        public IQueryable<ArchiveTBLDTO> GetAllDTO()
        {
            var archiveTBL = db.GetAllArchiveTBL();
            var result = archiveTBL.AsQueryable().Select(ArchiveTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ArchiveTBLs/GetByParams")]
        [HttpGet]
        public IQueryable<ArchiveTBLDTO> GetByParams(ArchiveTBLDTO model)
        {
            var archiveTBL = db.GetArchiveTBLByParam(model.Details,
                                                                model.ProjectID,
                                                                model.DocumentType,
                                                                model.WithHardCopy
                                                                );
            var result = archiveTBL.AsQueryable().Select(ArchiveTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ArchiveTBLs/GetByLike")]
        [HttpGet]
        public IQueryable<ArchiveTBLDTO> GetByLike(ArchiveTBLDTO model)
        {
            var archiveTBL = db.GetLikeArchiveTBL(model.Details,
                                                  model.ProjectID);
            var result = archiveTBL.AsQueryable().Select(ArchiveTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ArchiveTBLs
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ArchiveTBLs/GetAll")]
        [HttpGet]
        public IQueryable<ArchiveTBL> GetAll()
        {
            return db.ArchiveTBLs;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ArchiveTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ArchiveTBL))]
        [Route("api/ArchiveTBLs/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            ArchiveTBL archiveTBL = await db.ArchiveTBLs.FindAsync(id);
            if (archiveTBL == null)
            {
                return NotFound();
            }

            return Ok(archiveTBL);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/ArchiveTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/ArchiveTBLs/Update/{ID:int}")]
        [HttpPut]      
        public async Task<IHttpActionResult> Update(int id, ArchiveTBLDTO archiveTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archiveTBL.ID)
            {
                return BadRequest();
            }

            ArchiveTBL TBL = new ArchiveTBL();
            TBL = archiveTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(ArchiveTBLDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/ArchiveTBLs
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ArchiveTBL))]
        [Route("api/ArchiveTBLs/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(ArchiveTBLDTO archiveTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ArchiveTBL TBL = new ArchiveTBL();
            TBL = archiveTBL.GetOriginal(TBL);
            db.ArchiveTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(ArchiveTBLDTO.GetDTO(TBL));

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (ArchiveTBLExists(archiveTBL.ID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = archiveTBL.ID }, archiveTBL);
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/ArchiveTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ArchiveTBL))]
        [Route("api/ArchiveTBLs/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            ArchiveTBL archiveTBL = await db.ArchiveTBLs.FindAsync(id);
            if (archiveTBL == null)
            {
                return NotFound();
            }

            db.ArchiveTBLs.Remove(archiveTBL);
            await db.SaveChangesAsync();

            return Ok(archiveTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArchiveTBLExists(int id)
        {
            return db.ArchiveTBLs.Count(e => e.ID == id) > 0;
        }
    }
}