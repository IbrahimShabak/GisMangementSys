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
    public class DivisionTBLsController : ApiController
    {
        private EmployeeDBGIS2019Entities db = new EmployeeDBGIS2019Entities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DivisionTBLs/GetAllDTO")]
        [HttpGet]
        public IQueryable<DivisionTBLDTO> GetAllDTO()
        {
            var divisionTBL = db.GetAllDivisions();
            var result = divisionTBL.AsQueryable().Select(DivisionTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DivisionTBLs/GetByParams")]
        [HttpGet]
        public IQueryable<DivisionTBLDTO> GetByParams(DivisionTBLDTO model)
        {
            var divisionTBL = db.GetDivisionsByParam(model.DivisionID,
                                                                model.ArName,
                                                                model.EnName
                                                                );
            var result = divisionTBL.AsQueryable().Select(DivisionTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DivisionTBLs/GetByLike")]
        [HttpGet]
        public IQueryable<DivisionTBLDTO> GetByLike(DivisionTBLDTO model)
        {
            var divisionTBL = db.GetLikeDivisions(model.ArName,
                                                  model.EnName);
            var result = divisionTBL.AsQueryable().Select(DivisionTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/DivisionTBLs
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DivisionTBLs/GetAll")]
        [HttpGet]
        public IQueryable<DivisionTBL> GetAll()
        {
            return db.DivisionTBLs;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/DivisionTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DivisionTBL))]
        [Route("api/DivisionTBLs/GetByID/{ID:int}")]
        [HttpGet]
      
        public async Task<IHttpActionResult> GetDivisionTBL(int id)
        {
            DivisionTBL divisionTBL = await db.DivisionTBLs.FindAsync(id);
            if (divisionTBL == null)
            {
                return NotFound();
            }

            return Ok(divisionTBL);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/DivisionTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/DivisionTBLs/Update/{ID:int}")]
        [HttpPut]

        public async Task<IHttpActionResult> Update(int id, DivisionTBLDTO divisionTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != divisionTBL.DivisionID)
            {
                return BadRequest();
            }

            DivisionTBL TBL = new DivisionTBL();
            TBL = divisionTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivisionTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(DivisionTBLDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/DivisionTBLs
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DivisionTBL))]
        [Route("api/DivisionTBLs/Add")]
        [HttpPost]

        public async Task<IHttpActionResult> PostDivisionTBL(DivisionTBLDTO divisionTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DivisionTBL TBL = new DivisionTBL();
            TBL = divisionTBL.GetOriginal(TBL);
            db.DivisionTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(DivisionTBLDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/DivisionTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DivisionTBL))]
        [Route("api/DivisionTBLs/Delete/{ID:int}")]
        [HttpDelete]

        public async Task<IHttpActionResult> DeleteDivisionTBL(int id)
        {
            DivisionTBL divisionTBL = await db.DivisionTBLs.FindAsync(id);
            if (divisionTBL == null)
            {
                return NotFound();
            }

            db.DivisionTBLs.Remove(divisionTBL);
            await db.SaveChangesAsync();

            return Ok(divisionTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DivisionTBLExists(int id)
        {
            return db.DivisionTBLs.Count(e => e.DivisionID == id) > 0;
        }
    }
}