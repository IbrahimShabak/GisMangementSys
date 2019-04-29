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
    public class PositionInProjectsController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/PositionInProjects/GetAllS")]
        [HttpGet]
        public IQueryable<PositionInProjectDTO> GetAllPositionInProjects()
        {
            var PositionInProjects = db.SelectAllPositionInProject();
            var result = PositionInProjects.AsQueryable().Select(PositionInProjectDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/PositionInProjects/GetByParam")]
        [HttpGet]
        public IQueryable<PositionInProjectDTO> SelectParamContractChange(PositionInProjectDTO model)
        {
            var PositionInProjects = db.SelectParamPositionInProject(model.ID,
                                                                model.ArName,
                                                                model.EnName                                                                
                                                                );
            var result = PositionInProjects.AsQueryable().Select(PositionInProjectDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/PositionInProjects
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/PositionInProjects/GetAll")]
        [HttpGet]
        public IQueryable<PositionInProject> GetPositionInProjects()
        {
            return db.PositionInProjects;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/PositionInProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(PositionInProject))]
        [Route("api/PositionInProjects/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPositionInProject(int id)
        {
            PositionInProject positionInProject = await db.PositionInProjects.FindAsync(id);
            if (positionInProject == null)
            {
                return NotFound();
            }

            return Ok(positionInProject);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/PositionInProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/PositionInProjects/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutPositionInProject(int id, PositionInProjectDTO positionInProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != positionInProject.ID)
            {
                return BadRequest();
            }

            PositionInProject TBL = new PositionInProject();
            TBL = positionInProject.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionInProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(PositionInProjectDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/PositionInProjects
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(PositionInProject))]
        [Route("api/PositionInProjects/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostPositionInProject(PositionInProjectDTO positionInProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PositionInProject TBL = new PositionInProject();
            TBL = positionInProject.GetOriginal(TBL);
            db.PositionInProjects.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(PositionInProjectDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/PositionInProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(PositionInProject))]
        [Route("api/PositionInProjects/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePositionInProject(int id)
        {
            PositionInProject positionInProject = await db.PositionInProjects.FindAsync(id);
            if (positionInProject == null)
            {
                return NotFound();
            }

            db.PositionInProjects.Remove(positionInProject);
            await db.SaveChangesAsync();

            return Ok(positionInProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PositionInProjectExists(int id)
        {
            return db.PositionInProjects.Count(e => e.ID == id) > 0;
        }
    }
}