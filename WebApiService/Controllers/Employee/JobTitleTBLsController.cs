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
using DAL.Entities.Employees;
using DAL.Operations.DTO.Employee;

namespace WebApiService.Controllers.Employee
{
    [MyAuthorize(Roles = "admin")]
    public class JobTitleTBLsController : ApiController
    {
        private EmployeeDBGIS2019Entities db = new EmployeeDBGIS2019Entities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/JobTitleTBLs/GetAllDTO")]
        [HttpGet]
        public IQueryable<JobTitleTBLDTO> GetAllDTO()
        {
            var jobTitleTBL = db.GetAllJobTitles();
            var result = jobTitleTBL.AsQueryable().Select(JobTitleTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/JobTitleTBLs/GetByParams")]
        [HttpGet]
        public IQueryable<JobTitleTBLDTO> GetByParams(JobTitleTBLDTO model)
        {
            var jobTitleTBL = db.GetJobTitlesByParam( model.ArName,
                                                      model.EnName
                                                                );
            var result = jobTitleTBL.AsQueryable().Select(JobTitleTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/JobTitleTBLs/GetByLike")]
        [HttpGet]
        public IQueryable<JobTitleTBLDTO> GetByLike(JobTitleTBLDTO model)
        {
            var jobTitleTBL = db.GetLikeJobTitles(model.ArName,
                                                  model.EnName);
            var result = jobTitleTBL.AsQueryable().Select(JobTitleTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/JobTitleTBLs
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/JobTitleTBLs/GetAll")]
        [HttpGet]
        public IQueryable<JobTitleTBL> GetJobTitleTBLs()
        {
            return db.JobTitleTBLs;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/JobTitleTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(JobTitleTBL))]
        [Route("api/JobTitleTBLs/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetJobTitleTBL(int id)
        {
            JobTitleTBL jobTitleTBL = await db.JobTitleTBLs.FindAsync(id);
            if (jobTitleTBL == null)
            {
                return NotFound();
            }

            return Ok(jobTitleTBL);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/JobTitleTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/JobTitleTBLs/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutJobTitleTBL(int id, JobTitleTBLDTO jobTitleTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobTitleTBL.JobTitleID)
            {
                return BadRequest();
            }

            JobTitleTBL TBL = new JobTitleTBL();
            TBL = jobTitleTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTitleTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(JobTitleTBLDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/JobTitleTBLs
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(JobTitleTBL))]
        [Route("api/JobTitleTBLs/Add")]
        [HttpPost]
      
      
        public async Task<IHttpActionResult> PostJobTitleTBL(JobTitleTBLDTO jobTitleTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobTitleTBL TBL = new JobTitleTBL();
            TBL = jobTitleTBL.GetOriginal(TBL);
            db.JobTitleTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(JobTitleTBLDTO.GetDTO(TBL));

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (JobTitleTBLExists(jobTitleTBL.JobTitleID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = jobTitleTBL.JobTitleID }, jobTitleTBL);
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/JobTitleTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(JobTitleTBL))]
        [Route("api/JobTitleTBLs/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteJobTitleTBL(int id)
        {
            JobTitleTBL jobTitleTBL = await db.JobTitleTBLs.FindAsync(id);
            if (jobTitleTBL == null)
            {
                return NotFound();
            }

            db.JobTitleTBLs.Remove(jobTitleTBL);
            await db.SaveChangesAsync();

            return Ok(jobTitleTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobTitleTBLExists(int id)
        {
            return db.JobTitleTBLs.Count(e => e.JobTitleID == id) > 0;
        }
    }
}