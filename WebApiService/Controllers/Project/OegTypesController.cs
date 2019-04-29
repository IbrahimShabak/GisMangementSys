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
    public class OegTypesController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OegTypes/GetAllS")]
        [HttpGet]
        public IQueryable<OegTypeDTO> GetAllOegType()
        {
            var OegTypes = db.SelectAllOegType();
            var result = OegTypes.AsQueryable().Select(OegTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/OegTypes
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OegTypes/GetAll")]
        [HttpGet]
        public IQueryable<OegType> GetOegTypes()
        {
            return db.OegTypes;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/OegTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OegType))]
        [Route("api/OegTypes/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOegType(int id)
        {
            OegType oegType = await db.OegTypes.FindAsync(id);
            if (oegType == null)
            {
                return NotFound();
            }

            return Ok(oegType);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/OegTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/OegTypes/Update/{ID:int}")]
        [HttpPut]   
        public async Task<IHttpActionResult> PutOegType(int id, OegTypeDTO oegType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oegType.OrgTypeID)
            {
                return BadRequest();
            }

            OegType TBL = new OegType();
            TBL = oegType.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OegTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(OegTypeDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/OegTypes
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OegType))]
        [Route("api/OegTypes/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostOegType(OegTypeDTO oegType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OegType TBL = new OegType();
            TBL = oegType.GetOriginal(TBL);
            db.OegTypes.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(OegTypeDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/OegTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OegType))]
        [Route("api/OegTypes/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOegType(int id)
        {
            OegType oegType = await db.OegTypes.FindAsync(id);
            if (oegType == null)
            {
                return NotFound();
            }

            db.OegTypes.Remove(oegType);
            await db.SaveChangesAsync();

            return Ok(oegType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OegTypeExists(int id)
        {
            return db.OegTypes.Count(e => e.OrgTypeID == id) > 0;
        }
    }
}