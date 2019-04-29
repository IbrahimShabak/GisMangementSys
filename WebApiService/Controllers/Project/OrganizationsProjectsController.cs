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
    public class OrganizationsProjectsController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OrganizationsProjects/GetAllS")]
        [HttpGet]
        public IQueryable<OrganizationsProjectDTO> GetAllOrganizationsProject()
        {
            var contractsChanges = db.SelectAllOrganizationProject();
            var result = contractsChanges.AsQueryable().Select(OrganizationsProjectDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OrganizationsProjects/GetByParam")]
        [HttpGet]
        public IQueryable<OrganizationsProjectDTO> SelectParamOrganizationsProject(OrganizationsProjectDTO model)
        {
            var contractsChanges = db.SelectParamOrganizationProject(model.SerNum,
                                                                model.PeopleID,
                                                                model.ProjectID,
                                                                model.OrgTypeID
                                                                );
            var result = contractsChanges.AsQueryable().Select(OrganizationsProjectDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/OrganizationsProjects
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/OrganizationsProjects/GetAll")]
        [HttpGet]
        public IQueryable<OrganizationsProject> GetOrganizationsProjects()
        {
            return db.OrganizationsProjects;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/OrganizationsProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OrganizationsProject))]
        [Route("api/OrganizationsProjects/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOrganizationsProject(int id)
        {
            OrganizationsProject organizationsProject = await db.OrganizationsProjects.FindAsync(id);
            if (organizationsProject == null)
            {
                return NotFound();
            }

            return Ok(organizationsProject);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/OrganizationsProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/OrganizationsProjects/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutOrganizationsProject(int id, OrganizationsProjectDTO organizationsProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizationsProject.SerNum)
            {
                return BadRequest();
            }

            OrganizationsProject TBL = new OrganizationsProject();
            TBL = organizationsProject.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationsProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(OrganizationsProjectDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/OrganizationsProjects
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OrganizationsProject))]
        [Route("api/OrganizationsProjects/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostOrganizationsProject(OrganizationsProjectDTO organizationsProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrganizationsProject TBL = new OrganizationsProject();
            TBL = organizationsProject.GetOriginal(TBL);
            db.OrganizationsProjects.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(OrganizationsProjectDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/OrganizationsProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(OrganizationsProject))]
        [Route("api/OrganizationsProjects/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOrganizationsProject(int id)
        {
            OrganizationsProject organizationsProject = await db.OrganizationsProjects.FindAsync(id);
            if (organizationsProject == null)
            {
                return NotFound();
            }

            db.OrganizationsProjects.Remove(organizationsProject);
            await db.SaveChangesAsync();

            return Ok(organizationsProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationsProjectExists(int id)
        {
            return db.OrganizationsProjects.Count(e => e.SerNum == id) > 0;
        }
    }
}