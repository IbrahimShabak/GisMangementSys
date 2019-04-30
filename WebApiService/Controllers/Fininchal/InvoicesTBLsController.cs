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
    public class InvoicesTBLsController : ApiController
    {
        private FinancialDBEntities db = new FinancialDBEntities();

        // GET: api/InvoicesTBLs
        public IQueryable<InvoicesTBL> GetInvoicesTBLs()
        {
            return db.InvoicesTBLs;
        }

        // GET: api/InvoicesTBLs/5
        [ResponseType(typeof(InvoicesTBL))]
        public async Task<IHttpActionResult> GetInvoicesTBL(int id)
        {
            InvoicesTBL invoicesTBL = await db.InvoicesTBLs.FindAsync(id);
            if (invoicesTBL == null)
            {
                return NotFound();
            }

            return Ok(invoicesTBL);
        }

        // PUT: api/InvoicesTBLs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInvoicesTBL(int id, InvoicesTBL invoicesTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoicesTBL.RecordID)
            {
                return BadRequest();
            }

            db.Entry(invoicesTBL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesTBLExists(id))
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

        // POST: api/InvoicesTBLs
        [ResponseType(typeof(InvoicesTBL))]
        public async Task<IHttpActionResult> PostInvoicesTBL(InvoicesTBL invoicesTBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvoicesTBLs.Add(invoicesTBL);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = invoicesTBL.RecordID }, invoicesTBL);
        }

        // DELETE: api/InvoicesTBLs/5
        [ResponseType(typeof(InvoicesTBL))]
        public async Task<IHttpActionResult> DeleteInvoicesTBL(int id)
        {
            InvoicesTBL invoicesTBL = await db.InvoicesTBLs.FindAsync(id);
            if (invoicesTBL == null)
            {
                return NotFound();
            }

            db.InvoicesTBLs.Remove(invoicesTBL);
            await db.SaveChangesAsync();

            return Ok(invoicesTBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoicesTBLExists(int id)
        {
            return db.InvoicesTBLs.Count(e => e.RecordID == id) > 0;
        }
    }
}