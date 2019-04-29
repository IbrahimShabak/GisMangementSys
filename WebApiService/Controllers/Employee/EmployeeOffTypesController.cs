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
    public class EmployeeOffTypesController : ApiController
    {
        private EmployeeDBGIS2019Entities db = new EmployeeDBGIS2019Entities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeOffTypes/GetAllDTO")]
        [HttpGet]
        public IQueryable<EmployeeOffTypeDTO> GetAllDTO()
        {
            var employeeOffType = db.GetAllEmployeeOffTypes();
            var result = employeeOffType.AsQueryable().Select(EmployeeOffTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeOffTypes/GetByParams")]
        [HttpGet]
        public IQueryable<EmployeeOffTypeDTO> GetByParams(EmployeeOffTypeDTO model)
        {
            var employeeOffType = db.GetEmployeeOffTypesByParam(model.EmployeeOffTypeID,
                                                                model.ArName,
                                                                model.EnName
                                                                );
            var result = employeeOffType.AsQueryable().Select(EmployeeOffTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeOffTypes/GetByLike")]
        [HttpGet]
        public IQueryable<EmployeeOffTypeDTO> GetByLike(EmployeeOffTypeDTO model)
        {
            var employeeOffType = db.GetLikeEmployeeOffTypes(model.ArName,
                                                             model.EnName);
            var result = employeeOffType.AsQueryable().Select(EmployeeOffTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EmployeeOffTypes
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/EmployeeOffTypes/GetAll")]
        [HttpGet]
       
        public IQueryable<EmployeeOffType> GetEmployeeOffTypes()
        {
            return db.EmployeeOffTypes;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/EmployeeOffTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeOffType))]
        [Route("api/EmployeeOffTypes/GetByID/{ID:int}")]
        [HttpGet]

        public async Task<IHttpActionResult> GetEmployeeOffType(int id)
        {
            EmployeeOffType employeeOffType = await db.EmployeeOffTypes.FindAsync(id);
            if (employeeOffType == null)
            {
                return NotFound();
            }

            return Ok(employeeOffType);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/EmployeeOffTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/EmployeeOffTypes/Update/{ID:int}")]
        [HttpPut]

        public async Task<IHttpActionResult> PutEmployeeOffType(int id, EmployeeOffTypeDTO employeeOffType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeOffType.EmployeeOffTypeID)
            {
                return BadRequest();
            }

            EmployeeOffType TBL = new EmployeeOffType();
            TBL = employeeOffType.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeOffTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(EmployeeOffTypeDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/EmployeeOffTypes
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeOffType))]
        [Route("api/EmployeeOffTypes/Add")]
        [HttpPost]

        public async Task<IHttpActionResult> PostEmployeeOffType(EmployeeOffTypeDTO employeeOffType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeOffType TBL = new EmployeeOffType();
            TBL = employeeOffType.GetOriginal(TBL);
            db.EmployeeOffTypes.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(EmployeeOffTypeDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/EmployeeOffTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(EmployeeOffType))]
        [Route("api/EmployeeOffTypes/Delete/{ID:int}")]
        [HttpDelete]

        public async Task<IHttpActionResult> DeleteEmployeeOffType(int id)
        {
            EmployeeOffType employeeOffType = await db.EmployeeOffTypes.FindAsync(id);
            if (employeeOffType == null)
            {
                return NotFound();
            }

            db.EmployeeOffTypes.Remove(employeeOffType);
            await db.SaveChangesAsync();

            return Ok(employeeOffType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeOffTypeExists(int id)
        {
            return db.EmployeeOffTypes.Count(e => e.EmployeeOffTypeID == id) > 0;
        }
    }
}