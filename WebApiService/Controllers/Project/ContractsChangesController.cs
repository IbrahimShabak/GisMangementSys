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
    public class ContractsChangesController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ContractsChanges/GetAllDTO")]
        [HttpGet]
        public IQueryable<ContractsChangeDTO> GetAllDTO()
        {
            var contractsChanges = db.SelectAllContractsChange();
            var result = contractsChanges.AsQueryable().Select(ContractsChangeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ContractsChanges/GetByParams")]
        [HttpGet]
        public IQueryable<ContractsChangeDTO> GetByParams(ContractsChangeDTO model)
        {
            var contractsChanges = db.SelectParamContractChange(model.ID,
                                                                model.ProjectID,
                                                                model.ChangedDescription,
                                                                model.OriginalAmount,
                                                                model.NewAmount
                                                                );
            var result = contractsChanges.AsQueryable().Select(ContractsChangeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ContractsChanges/GetByLike")]
        [HttpGet]
        public IQueryable<ContractsChangeDTO> GetByLike(ContractsChangeDTO model)
        {
            var contractsChanges = db.SelectlikeContractChange(model.ChangedDescription);
            var result = contractsChanges.AsQueryable().Select(ContractsChangeDTO.Mapper.SelectorExpression);
            return result;
        }

        //--------------------------------------------------------------------------------------------
        // GET: api/ContractsChanges
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/ContractsChanges/GetAll")]
        [HttpGet]
        public IQueryable<ContractsChange> GetAll()
        {
            return db.ContractsChanges;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/ContractsChanges/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ContractsChange))]
        [Route("api/ContractsChanges/GetByID/{ID:int}")]
        [HttpGet]
       
        public async Task<IHttpActionResult> GetByID(int id)
        {
            ContractsChange contractsChange = await db.ContractsChanges.FindAsync(id);
            if (contractsChange == null)
            {
                return NotFound();
            }

            return Ok(contractsChange);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/ContractsChanges/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/ContractsChanges/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, ContractsChangeDTO contractsChange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contractsChange.ID)
            {
                return BadRequest();
            }
            ContractsChange TBL = new ContractsChange();
            TBL = contractsChange.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;
            

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractsChangeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(ContractsChangeDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/ContractsChanges
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ContractsChange))]
        [Route("api/ContractsChanges/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(ContractsChangeDTO contractsChange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ContractsChange TBL = new ContractsChange();
            TBL = contractsChange.GetOriginal(TBL);
            db.ContractsChanges.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(ContractsChangeDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/ContractsChanges/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(ContractsChange))]
        [Route("api/ContractsChanges/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            ContractsChange contractsChange = await db.ContractsChanges.FindAsync(id);
            if (contractsChange == null)
            {
                return NotFound();
            }

            db.ContractsChanges.Remove(contractsChange);
            await db.SaveChangesAsync();

            return Ok(contractsChange);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContractsChangeExists(int id)
        {
            return db.ContractsChanges.Count(e => e.ID == id) > 0;
        }
    }
}