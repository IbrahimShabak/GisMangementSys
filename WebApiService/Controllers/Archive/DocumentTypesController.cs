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

namespace WebApiService.Controllers.Archive
{
    public class DocumentTypesController : ApiController
    {
        private ArchiveDBEntities db = new ArchiveDBEntities();

        // GET: api/DocumentTypes
        public IQueryable<DocumentType> GetDocumentTypes()
        {
            return db.DocumentTypes;
        }

        // GET: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public async Task<IHttpActionResult> GetDocumentType(int id)
        {
            DocumentType documentType = await db.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }

            return Ok(documentType);
        }

        // PUT: api/DocumentTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocumentType(int id, DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentType.ID)
            {
                return BadRequest();
            }

            db.Entry(documentType).State = EntityState.Modified;

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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DocumentTypes
        [ResponseType(typeof(DocumentType))]
        public async Task<IHttpActionResult> PostDocumentType(DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentTypes.Add(documentType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocumentTypeExists(documentType.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = documentType.ID }, documentType);
        }

        // DELETE: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public async Task<IHttpActionResult> DeleteDocumentType(int id)
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