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
    public class StageProjectsController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/StageProjects/GetAllS")]
        [HttpGet]
        public IQueryable<StageProjectDTO> GetAllStageProject()
        {
            var StageProjects = db.SelectAllStageProject();
            var result = StageProjects.AsQueryable().Select(StageProjectDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/StageProjects/GetByParam")]
        [HttpGet]
        public IQueryable<StageProjectDTO> SelectParamStageProjects(StageProjectDTO model)
        {
            var StageProjects = db.SelectParamStageProject(model.StageID,
                                                                model.ProjectID,
                                                                model.StageArName,
                                                                model.StageEnName,
                                                                model.StageBudget
                                                                );
            var result = StageProjects.AsQueryable().Select(StageProjectDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/StageProjects/GetByLike")]
        [HttpGet]
        public IQueryable<StageProjectDTO> SelectlikeStageProjects(StageProjectDTO model)
        {
            var StageProjects = db.SelectLikeStageProject(model.StageArName,
                                                          model.StageEnName
                                                         );
            var result = StageProjects.AsQueryable().Select(StageProjectDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/StageProjects
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/StageProjects/GetAll")]
        [HttpGet]
        public IQueryable<StageProject> GetStageProjects()
        {
            return db.StageProjects;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/StageProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(StageProject))]
        [Route("api/StageProjects/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetStageProject(int id)
        {
            StageProject stageProject = await db.StageProjects.FindAsync(id);
            if (stageProject == null)
            {
                return NotFound();
            }

            return Ok(stageProject);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/StageProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/StageProjects/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutStageProject(int id, StageProjectDTO stageProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stageProject.StageID)
            {
                return BadRequest();
            }

            StageProject TBL = new StageProject();
            TBL = stageProject.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StageProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(StageProjectDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/StageProjects
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(StageProject))]
        [Route("api/StageProjects/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostStageProject(StageProjectDTO stageProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StageProject TBL = new StageProject();
            TBL = stageProject.GetOriginal(TBL);
            db.StageProjects.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(StageProjectDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/StageProjects/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(StageProject))]
        [Route("api/StageProjects/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStageProject(int id)
        {
            StageProject stageProject = await db.StageProjects.FindAsync(id);
            if (stageProject == null)
            {
                return NotFound();
            }

            db.StageProjects.Remove(stageProject);
            await db.SaveChangesAsync();

            return Ok(stageProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StageProjectExists(int id)
        {
            return db.StageProjects.Count(e => e.StageID == id) > 0;
        }
    }
}