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
    public class EmployeeTBLsController : ApiController
    {
        private EmployeeDBGIS2019Entities db = new EmployeeDBGIS2019Entities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeTBLs/GetAllDTO")]
        [HttpGet]
        public IQueryable<EmployeeTBLDTO> GetAllDTO()
        {
            var employeeTBLs = db.GetAllEmployees();
            var result = employeeTBLs.AsQueryable().Select(EmployeeTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeTBLs/GetByParams")]
        [HttpGet]
        public IQueryable<EmployeeTBLDTO> GetByParams(EmployeeTBLDTO model)
        {
            var employeeTBLs = db.GetEmployeesByParam(model.EmployeeID,
                                                                model.ArName,
                                                                model.EnName,
                                                                model.StartDate,
                                                                model.BithDate,
                                                                model.NationalityID,
                                                                model.DivisionID,
                                                                model.JobTitleID,
                                                                model.PhoneNumber,
                                                                model.IsActiveStatus,
                                                                model.EmailAddress,
                                                                model.OffDate,
                                                                model.OffTypeID
                                                                );
            var result = employeeTBLs.AsQueryable().Select(EmployeeTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeTBLs/GetByLike")]
        [HttpGet]
        public IQueryable<EmployeeTBLDTO> GetByLike(EmployeeTBLDTO model)
        {
            var employeeTBLs = db.GetLikeEmployees(model.EmployeeID,
                                                   model.ArName,
                                                   model.EnName,
                                                   model.EmailAddress);
            var result = employeeTBLs.AsQueryable().Select(EmployeeTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EmployeeTBLs
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeTBLs/GetAll")]
        [HttpGet]
        public IQueryable<EmployeeTBL> GetEmployeeTBLs()
        {
            return db.EmployeeTBLs;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EmployeeTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeTBL))]
        [Route("api/EmployeeTBLs/GetByID/{ID:int}")]
        [HttpGet]

        public async Task<IHttpActionResult> GetEmployeeTBL(int id)
        {
            EmployeeTBL employeeTBL = await db.EmployeeTBLs.FindAsync(id);
            if (employeeTBL == null)
            {
                return NotFound();
            }

            return Ok(employeeTBL);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/EmployeeTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/EmployeeTBLs/Update/{ID:int}")]
        [HttpPut]

        public async Task<IHttpActionResult> PutEmployeeTBL(int id, EmployeeTBLDTO employeeTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeTBL.EmployeeID)
            {
                return BadRequest();
            }

            EmployeeTBL TBL = new EmployeeTBL();
            TBL = employeeTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(EmployeeTBLDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/EmployeeTBLs
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeTBL))]
        [Route("api/EmployeeTBLs/Add")]
        [HttpPost]

        public async Task<IHttpActionResult> PostEmployeeTBL(EmployeeTBLDTO employeeTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeTBL TBL = new EmployeeTBL();
            TBL = employeeTBL.GetOriginal(TBL);
            db.EmployeeTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(EmployeeTBLDTO.GetDTO(TBL));

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (EmployeeTBLExists(employeeTBL.EmployeeID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = employeeTBL.EmployeeID }, employeeTBL);
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/EmployeeTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeTBL))]
        [Route("api/EmployeeTBLs/Delete/{ID:int}")]
        [HttpDelete]

        public async Task<IHttpActionResult> DeleteEmployeeTBL(int id)
        {
            EmployeeTBL employeeTBL = await db.EmployeeTBLs.FindAsync(id);
            if (employeeTBL == null)
            {
                return NotFound();
            }

            db.EmployeeTBLs.Remove(employeeTBL);
            await db.SaveChangesAsync();

            return Ok(employeeTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeTBLExists(int id)
        {
            return db.EmployeeTBLs.Count(e => e.EmployeeID == id) > 0;
        }
    }
}