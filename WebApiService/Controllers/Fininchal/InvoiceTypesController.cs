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
using DAL.Entities.Fininchal;

namespace WebApiService.Controllers.Fininchal
{
    [MyAuthorize(Roles = "admin")]
    public class InvoiceTypesController : ApiController
    {
        private FinancialDBEntities db = new FinancialDBEntities();

        //****************************************************************************************
        // GET: api/InvoiceTypes
        [MyAuthorize(Roles = "admin")]
        public IQueryable<InvoiceType> GetInvoiceTypes()
        {
            return db.InvoiceTypes;
        }
        //****************************************************************************************

        // GET: api/InvoiceTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(InvoiceType))]
        public async Task<IHttpActionResult> GetInvoiceType(int id)
        {
            InvoiceType invoiceType = await db.InvoiceTypes.FindAsync(id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            return Ok(invoiceType);
        }
        //****************************************************************************************

        // PUT: api/InvoiceTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInvoiceType(int id, InvoiceType invoiceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoiceType.TypeID)
            {
                return BadRequest();
            }

            db.Entry(invoiceType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTypeExists(id))
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
        //****************************************************************************************

        // POST: api/InvoiceTypes
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(InvoiceType))]
        public async Task<IHttpActionResult> PostInvoiceType(InvoiceType invoiceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvoiceTypes.Add(invoiceType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = invoiceType.TypeID }, invoiceType);
        }
        //****************************************************************************************

        // DELETE: api/InvoiceTypes/5
        [MyAuthorize(Roles = "admin")]
        [ResponseType(typeof(InvoiceType))]
        public async Task<IHttpActionResult> DeleteInvoiceType(int id)
        {
            InvoiceType invoiceType = await db.InvoiceTypes.FindAsync(id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            db.InvoiceTypes.Remove(invoiceType);
            await db.SaveChangesAsync();

            return Ok(invoiceType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoiceTypeExists(int id)
        {
            return db.InvoiceTypes.Count(e => e.TypeID == id) > 0;
        }
    }
}