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
using DAL.Entities.ToDoList;
using DAL.Operations.DTO.ToDoList;

namespace WebApiService.Controllers.ToDoList
{
    [MyAuthorize(Roles = "admin")]
    public class ProiertyTypesController : ApiController
    {
        private TODoListGISEntities db = new TODoListGISEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ProiertyTypes/GetAllDTO")]
        [HttpGet]
        public IQueryable<ProiertyTypeDTO> GetAllDTO()
        {
            var proiertyType = db.GetAllProiertyType();
            var result = proiertyType.AsQueryable().Select(ProiertyTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ProiertyTypes/GetByParams")]
        [HttpGet]
        public IQueryable<ProiertyTypeDTO> GetByParams(ProiertyTypeDTO model)
        {
            var proiertyType = db.GetProiertyTypeByParam(model.ArName,
                                                         model.EnName
                                                         );
            var result = proiertyType.AsQueryable().Select(ProiertyTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ProiertyTypes
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ProiertyTypes/GetAll")]
        [HttpGet]
        public IQueryable<ProiertyType> GetAll()
        {
            return db.ProiertyTypes;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ProiertyTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ProiertyType))]
        [Route("api/DivisionTBLs/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            ProiertyType proiertyType = await db.ProiertyTypes.FindAsync(id);
            if (proiertyType == null)
            {
                return NotFound();
            }

            return Ok(proiertyType);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/ProiertyTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/ProiertyTypes/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, ProiertyTypeDTO proiertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proiertyType.ID)
            {
                return BadRequest();
            }

            ProiertyType TBL = new ProiertyType();
            TBL = proiertyType.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProiertyTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(ProiertyTypeDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/ProiertyTypes
        [ResponseType(typeof(ProiertyType))]
        public async Task<IHttpActionResult> Add(ProiertyTypeDTO proiertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProiertyType TBL = new ProiertyType();
            TBL = proiertyType.GetOriginal(TBL);
            db.ProiertyTypes.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(ProiertyTypeDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/ProiertyTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ProiertyType))]
        [Route("api/ProiertyTypes/Delete/{ID:int}")]
        [HttpDelete]      
        public async Task<IHttpActionResult> Delete(int id)
        {
            ProiertyType proiertyType = await db.ProiertyTypes.FindAsync(id);
            if (proiertyType == null)
            {
                return NotFound();
            }

            db.ProiertyTypes.Remove(proiertyType);
            await db.SaveChangesAsync();

            return Ok(proiertyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProiertyTypeExists(int id)
        {
            return db.ProiertyTypes.Count(e => e.ID == id) > 0;
        }
    }
}