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
    //[AllowAnonymous]
    public class ProjectTBLsController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();

        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/ProjectTBLs/GetAllS")]
        [HttpGet]
        public IQueryable<ProjectDTO> GetAllProjectTBLs()
        {
            var ProjectTBLs = db.SelectAllProjectTBL();
            // var ProjectTBLs = db.ProjectTBLs;
            var result = ProjectTBLs.AsQueryable().Select(ProjectDTO.Mapper.SelectorExpression);
            return result;
        }

        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ProjectTBLs/GetByParam")]
        [HttpGet]
        public IQueryable<ProjectDTO> SelectParamProjectTBL(ProjectDTO model)
        {
            var ProjectTBLs = db.SelectParamProjectTBL(model.ProjectID,
                                                                model.ProjectNumber,
                                                                model.ArName,
                                                                model.EnName,
                                                                model.MainContractAmount,
                                                                model.IsActiveProject
                                                                );
            var result = ProjectTBLs.AsQueryable().Select(ProjectDTO.Mapper.SelectorExpression);
            return result;
        }

        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ProjectTBLs/GetByLike")]
        [HttpGet]
        public IQueryable<ProjectDTO> SelectlikeContractChange(ProjectDTO model)
        {
            var ProjectTBLs = db.SelectLikeProjectTBL(model.ProjectNumber,
                                                      model.ArName,
                                                      model.EnName
                                                         );
            var result = ProjectTBLs.AsQueryable().Select(ProjectDTO.Mapper.SelectorExpression);
            return result;
        }

        //--------------------------------------------------------------------------------------------
        // GET: api/ProjectTBLs
        //[MyAuthorize(Roles = "Admin")]
        /// <summary>
        /// Get the project TB ls.
        /// </summary>
        /// <returns>The <see cref="T:IQueryable{ProjectTBL}"/>.</returns>
        [Route("api/ProjectTBLs/GetAll")]
        [HttpGet]
        public IQueryable<ProjectTBL> GetProjectTBLs()
        {
            return db.ProjectTBLs;
        }

        //--------------------------------------------------------------------------------------------
        // GET: api/ProjectTBLs/5
        /// <summary>
        /// Get the projects by emp ID.
        /// </summary>
        /// <param name="EmpID">The EmpID.</param>
        /// <returns>The <see cref="T:IQueryable{ProjectDTO}"/>.</returns>
        [MyAuthorize]
        [ResponseType(typeof(ProjectDTO))]
        [Route("api/ProjectTBLs/GetProjectsByEmpID/{EmpID:int}")]
        [HttpGet]
        public IQueryable<ProjectDTO> GetProjectsByEmpID(int EmpID)
        {
            var projects = db.ProjectEmployees
                .Where(a => a.EmpID == EmpID)
                .Select(s => s.ProjectTBL).AsQueryable()
                .Select(ProjectDTO.Mapper.SelectorExpression);
            return projects;
        }

        //--------------------------------------------------------------------------------------------
        // GET: api/ProjectTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ProjectTBL))]
        [Route("api/ProjectTBLs/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProjectTBL(int id)
        {
            ProjectTBL projectTBL = await db.ProjectTBLs.FindAsync(id);
            if (projectTBL == null)
            {
                return NotFound();
            }

            return Ok(projectTBL);
        }

        //--------------------------------------------------------------------------------------------
        // PUT: api/ProjectTBLs/5
        [MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/ProjectTBLs/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutProjectTBL(int id, ProjectDTO projectTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTBL.ProjectID)
            {
                return BadRequest();
            }
            ProjectTBL TBL = new ProjectTBL();
            TBL = projectTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(ProjectDTO.GetDTO(TBL));
            //  return StatusCode(HttpStatusCode.NoContent);
        }

        //--------------------------------------------------------------------------------------------
        // POST: api/ProjectTBLs
        [MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ProjectDTO))]
        [Route("api/ProjectTBLs/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostProjectTBL(ProjectDTO projectTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ProjectTBL TBL = new ProjectTBL();
            TBL = projectTBL.GetOriginal(TBL);
            db.ProjectTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(ProjectDTO.GetDTO(TBL));
        }

        //--------------------------------------------------------------------------------------------
        // DELETE: api/ProjectTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ProjectTBL))]
        [Route("api/ProjectTBLs/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProjectTBL(int id)
        {
            ProjectTBL projectTBL = await db.ProjectTBLs.FindAsync(id);
            if (projectTBL == null)
            {
                return NotFound();
            }

            db.ProjectTBLs.Remove(projectTBL);
            await db.SaveChangesAsync();

            return Ok(projectTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectTBLExists(int id)
        {
            return db.ProjectTBLs.Count(e => e.ProjectID == id) > 0;
        }
    }
}