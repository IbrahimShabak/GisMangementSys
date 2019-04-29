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
    public class OrganizationBasicsController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OrganizationBasics/GetAllS")]
        [HttpGet]
        public IQueryable<OrganizationBasicDTO> GetAllOrganizationBasics()
        {
            var OrganizationBasics = db.SelectAllOrganizationBasics();
            var result = OrganizationBasics.AsQueryable().Select(OrganizationBasicDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OrganizationBasics/GetByParam")]
        [HttpGet]
        public IQueryable<OrganizationBasicDTO> SelectParamOrganizationBasic(OrganizationBasicDTO model)
        {
            var OrganizationBasic = db.SelectParamOrganizationBasics(model.OrgID,
                                                                model.OrgArName,
                                                                model.OrgEnName,
                                                                model.LandLineNumber                                                               
                                                                );
            var result = OrganizationBasic.AsQueryable().Select(OrganizationBasicDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OrganizationBasics/GetByLike")]
        [HttpGet]
        public IQueryable<OrganizationBasicDTO> SelectlikeOrganizationBasic(OrganizationBasicDTO model)
        {
            var likeOrganizationBasic = db.SelectlikeOrganizationBasic(model.OrgArName,
                                                                        model.OrgEnName
                                                                        );
            var result = likeOrganizationBasic.AsQueryable().Select(OrganizationBasicDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/OrganizationBasics
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OrganizationBasics/GetAll")]
        [HttpGet]
       
        public IQueryable<OrganizationBasic> GetOrganizationBasics()
        {
            return db.OrganizationBasics;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/OrganizationBasics/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OrganizationBasic))]
        [Route("api/OrganizationBasics/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOrganizationBasic(int id)
        {
            OrganizationBasic organizationBasic = await db.OrganizationBasics.FindAsync(id);
            if (organizationBasic == null)
            {
                return NotFound();
            }

            return Ok(organizationBasic);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/OrganizationBasics/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/OrganizationBasics/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutOrganizationBasic(int id, OrganizationBasicDTO organizationBasic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizationBasic.OrgID)
            {
                return BadRequest();
            }

            OrganizationBasic TBL = new OrganizationBasic();
            TBL = organizationBasic.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationBasicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(OrganizationBasicDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/OrganizationBasics
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OrganizationBasic))]
        [Route("api/OrganizationBasics/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostOrganizationBasic(OrganizationBasicDTO organizationBasic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrganizationBasic TBL = new OrganizationBasic();
            TBL = organizationBasic.GetOriginal(TBL);
            db.OrganizationBasics.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(OrganizationBasicDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/OrganizationBasics/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OrganizationBasic))]
        [Route("api/OrganizationBasics/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOrganizationBasic(int id)
        {
            OrganizationBasic organizationBasic = await db.OrganizationBasics.FindAsync(id);
            if (organizationBasic == null)
            {
                return NotFound();
            }

            db.OrganizationBasics.Remove(organizationBasic);
            await db.SaveChangesAsync();

            return Ok(organizationBasic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationBasicExists(int id)
        {
            return db.OrganizationBasics.Count(e => e.OrgID == id) > 0;
        }
    }
}