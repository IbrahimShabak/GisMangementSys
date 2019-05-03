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
using DAL.Entities.Archive;
using DAL.Operations.DTO.Archive;

namespace WebApiService.Controllers.Archive
{
    public class DocumentTypesController : ApiController
    {
        private ArchiveDBEntities db = new ArchiveDBEntities();
        //--------------------------------------------------------------------------------------------
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DocumentTypes/GetAllDTO")]
        [HttpGet]
        public IQueryable<DocumentTypeDTO> GetAllDTO()
        {
            var archiveTBL = db.GetAllDocumentType();
            var result = archiveTBL.AsQueryable().Select(DocumentTypeDTO.Mapper.SelectorExpression);
            return result;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/DocumentTypes
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/DocumentTypes/GetAll")]
        [HttpGet]
        public IQueryable<DocumentType> GetAll()
        {
            return db.DocumentTypes;
        }
        //--------------------------------------------------------------------------------------------
        // GET: api/DocumentTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DocumentType))]
        [Route("api/DocumentTypes/GetByID/{ID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            DocumentType documentType = await db.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }

            return Ok(documentType);
        }
        //--------------------------------------------------------------------------------------------
        // PUT: api/DocumentTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        [Route("api/DocumentTypes/Update/{ID:int}")]
        [HttpPut]      
        public async Task<IHttpActionResult> Update(int id, DocumentTypeDTO documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentType.ID)
            {
                return BadRequest();
            }

            DocumentType TBL = new DocumentType();
            TBL = documentType.GetOriginal(TBL);
            db.Entry(TBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(DocumentTypeDTO.GetDTO(TBL));
          //  return StatusCode(HttpStatusCode.NoContent);
        }
        //--------------------------------------------------------------------------------------------
        // POST: api/DocumentTypes
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DocumentType))]
        [Route("api/DocumentTypes/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(DocumentTypeDTO documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DocumentType TBL = new DocumentType();
            TBL = documentType.GetOriginal(TBL);
            db.DocumentTypes.Add(TBL);
            await db.SaveChangesAsync();

            //return Ok(ArchiveTBLDTO.GetDTO(TBL));

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (DocumentTypeExists(documentType.ID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = documentType.ID }, documentType);
        }
        //--------------------------------------------------------------------------------------------
        // DELETE: api/DocumentTypes/5
        //[MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(DocumentType))]
        [Route("api/DocumentTypes/Delete/{ID:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            DocumentType documentType = await db.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }

            db.DocumentTypes.Remove(documentType);
            await db.SaveChangesAsync();

            return Ok(documentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentTypeExists(int id)
        {
            return db.DocumentTypes.Count(e => e.ID == id) > 0;
        }
    }
}