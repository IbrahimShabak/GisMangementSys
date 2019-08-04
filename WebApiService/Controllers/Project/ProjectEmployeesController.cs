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
    public class ProjectEmployeesController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/ProjectEmployees/GetAllS")]
        [HttpGet]
        public IQueryable<ProjectEmployeeDTO> GetAllProjectEmployees()
        {
            var ProjectEmployees = db.SelectAllProjectEmployees();
            var result = ProjectEmployees.AsQueryable().Select(ProjectEmployeeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/ProjectEmployees/GetByParam")]
        [HttpGet]
        public IQueryable<ProjectEmployeeDTO> SelectParamProjectEmployees(ProjectEmployeeDTO model)
        {
            var ProjectEmployees = db.SelectParamProjectEmployees(model.ID,
                                                                model.ProjectID,
                                                                model.EmpID,
                                                                model.PositionInProject
                                                                );
            var result = ProjectEmployees.AsQueryable().Select(ProjectEmployeeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        [MyAuthorize(Roles = "admin")]
        [Route("api/ProjectEmployees/GetByLike")]
        [HttpGet]
        public IQueryable<ProjectEmployeeDTO> SelectlikeProjectEmployees(ProjectEmployeeDTO model)
        {
            var ProjectEmployees = db.SelectlikeProjectEmployees(model.ProjectID,
                                                                 model.EmpID
                                                                );
            var result = ProjectEmployees.AsQueryable().Select(ProjectEmployeeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ProjectEmployees
        [MyAuthorize(Roles = "admin")]
        [Route("api/ProjectEmployees/GetAll")]
        [HttpGet]
        public IQueryable<ProjectEmployee> GetProjectEmployees()
        {
            return db.ProjectEmployees;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ProjectEmployees/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(ProjectEmployee))]
        [Route("api/ProjectEmployees/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProjectEmployee(int id)
        {
            ProjectEmployee projectEmployee = await db.ProjectEmployees.FindAsync(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return Ok(projectEmployee);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/ProjectEmployees/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [Route("api/ProjectEmployees/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutProjectEmployee(int id, ProjectEmployeeDTO projectEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectEmployee.ID)
            {
                return BadRequest();
            }

            ProjectEmployee TBL = new ProjectEmployee();
            TBL = projectEmployee.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(ProjectEmployeeDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/ProjectEmployees
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(ProjectEmployee))]
        [Route("api/ProjectEmployees/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostProjectEmployee(ProjectEmployeeDTO projectEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProjectEmployee TBL = new ProjectEmployee();
            TBL = projectEmployee.GetOriginal(TBL);
            db.ProjectEmployees.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(ProjectEmployeeDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/ProjectEmployees/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(ProjectEmployee))]
        [Route("api/ProjectEmployees/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProjectEmployee(int id)
        {
            ProjectEmployee projectEmployee = await db.ProjectEmployees.FindAsync(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            db.ProjectEmployees.Remove(projectEmployee);
            await db.SaveChangesAsync();

            return Ok(projectEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectEmployeeExists(int id)
        {
            return db.ProjectEmployees.Count(e => e.ID == id) > 0;
        }
    }
}