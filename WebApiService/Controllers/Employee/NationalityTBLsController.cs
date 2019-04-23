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
    public class NationalityTBLsController : ApiController
    {
        private EmployeeDBGIS2019Entities db = new EmployeeDBGIS2019Entities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/NationalityTBLs/GetAllDTO")]
        [HttpGet]
        public IQueryable<NationalityTBLDTO> GetAllDTO()
        {
            var nationalityTBL = db.GetAllNationalitys();
            var result = nationalityTBL.AsQueryable().Select(NationalityTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/NationalityTBLs/GetByParams")]
        [HttpGet]
        public IQueryable<NationalityTBLDTO> GetByParams(NationalityTBLDTO model)
        {
            var nationalityTBL = db.GetNationalitysByParam(model.ArName,
                                                           model.EnName
                                                                );
            var result = nationalityTBL.AsQueryable().Select(NationalityTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/NationalityTBLs/GetByLike")]
        [HttpGet]
        public IQueryable<NationalityTBLDTO> GetByLike(NationalityTBLDTO model)
        {
            var nationalityTBL = db.GetLikeNationalitys(model.ArName,
                                                        model.EnName);
            var result = nationalityTBL.AsQueryable().Select(NationalityTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/NationalityTBLs
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/NationalityTBLs/GetAll")]
        [HttpGet]
        public IQueryable<NationalityTBL> GetNationalityTBLs()
        {
            return db.NationalityTBLs;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/NationalityTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(NationalityTBL))]
        [Route("api/NationalityTBLs/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetNationalityTBL(int id)
        {
            NationalityTBL nationalityTBL = await db.NationalityTBLs.FindAsync(id);
            if (nationalityTBL == null)
            {
                return NotFound();
            }

            return Ok(nationalityTBL);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/NationalityTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/NationalityTBLs/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutNationalityTBL(int id, NationalityTBLDTO nationalityTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nationalityTBL.NationalityID)
            {
                return BadRequest();
            }

            NationalityTBL TBL = new NationalityTBL();
            TBL = nationalityTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalityTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(NationalityTBLDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/NationalityTBLs
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(NationalityTBL))]
        [Route("api/NationalityTBLs/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostNationalityTBL(NationalityTBLDTO nationalityTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NationalityTBL TBL = new NationalityTBL();
            TBL = nationalityTBL.GetOriginal(TBL);
            db.NationalityTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(NationalityTBLDTO.GetDTO(TBL));

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (NationalityTBLExists(nationalityTBL.NationalityID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = nationalityTBL.NationalityID }, nationalityTBL);
        }

        // DELETE: api/NationalityTBLs/5
        [ResponseType(typeof(NationalityTBL))]
        public async Task<IHttpActionResult> DeleteNationalityTBL(int id)
        {
            NationalityTBL nationalityTBL = await db.NationalityTBLs.FindAsync(id);
            if (nationalityTBL == null)
            {
                return NotFound();
            }

            db.NationalityTBLs.Remove(nationalityTBL);
            await db.SaveChangesAsync();

            return Ok(nationalityTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NationalityTBLExists(int id)
        {
            return db.NationalityTBLs.Count(e => e.NationalityID == id) > 0;
        }
    }
}