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
    public class PepoleTBLsController : ApiController
    {
        private ProjectsEntities db = new ProjectsEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/PepoleTBLs/GetAllS")]
        [HttpGet]
        public IQueryable<PepoleTBLDTO> GetAllPepole()
        {
            var Pepole = db.SelectAllPepoleTBL();
            var result = Pepole.AsQueryable().Select(PepoleTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/PepoleTBLs/GetByParam")]
        [HttpGet]
        public IQueryable<PepoleTBLDTO> SelectParamContractChange(PepoleTBLDTO model)
        {
            var Pepole = db.SelectParamPepoleTBL(model.PeopleID,
                                                 model.ArName,
                                                 model.EnName,
                                                 model.MobilePhone,
                                                 model.LandLineExt,
                                                 model.EmailAdress,
                                                 model.OrgID
                                                                );
            var result = Pepole.AsQueryable().Select(PepoleTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/PepoleTBLs/GetByLike")]
        [HttpGet]
        public IQueryable<PepoleTBLDTO> SelectlikeContractChange(PepoleTBLDTO model)
        {
            var Pepole = db.SelectlikePepoleTBL(model.ArName,
                                                          model.EnName,
                                                          model.MobilePhone,
                                                          model.EmailAdress
                                                          
                                                                );
            var result = Pepole.AsQueryable().Select(PepoleTBLDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/PepoleTBLs
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/PepoleTBLs/GetAll")]
        [HttpGet]
        public IQueryable<PepoleTBL> GetPepoleTBLs()
        {
            return db.PepoleTBLs;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/PepoleTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(PepoleTBL))]
        [Route("api/PepoleTBLs/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPepoleTBL(int id)
        {
            PepoleTBL pepoleTBL = await db.PepoleTBLs.FindAsync(id);
            if (pepoleTBL == null)
            {
                return NotFound();
            }

            return Ok(pepoleTBL);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/PepoleTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/PepoleTBLs/Update/{ID:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutPepoleTBL(int id, PepoleTBLDTO pepoleTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pepoleTBL.PeopleID)
            {
                return BadRequest();
            }

            PepoleTBL TBL = new PepoleTBL();
            TBL = pepoleTBL.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PepoleTBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(PepoleTBLDTO.GetDTO(TBL));
           // return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/PepoleTBLs
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(PepoleTBL))]
        [Route("api/PepoleTBLs/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> PostPepoleTBL(PepoleTBLDTO pepoleTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PepoleTBL TBL = new PepoleTBL();
            TBL = pepoleTBL.GetOriginal(TBL);
            db.PepoleTBLs.Add(TBL);
            await db.SaveChangesAsync();

            return Ok(PepoleTBLDTO.GetDTO(TBL));
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/PepoleTBLs/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(PepoleTBL))]
        [Route("api/PepoleTBLs/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePepoleTBL(int id)
        {
            PepoleTBL pepoleTBL = await db.PepoleTBLs.FindAsync(id);
            if (pepoleTBL == null)
            {
                return NotFound();
            }

            db.PepoleTBLs.Remove(pepoleTBL);
            await db.SaveChangesAsync();

            return Ok(pepoleTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PepoleTBLExists(int id)
        {
            return db.PepoleTBLs.Count(e => e.PeopleID == id) > 0;
        }
    }
}