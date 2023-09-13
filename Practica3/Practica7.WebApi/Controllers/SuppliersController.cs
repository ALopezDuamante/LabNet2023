using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Practica7.WebApi.Data;
using Practica7.WebApi.Models;

namespace Practica7.WebApi.Controllers
{
    public class SuppliersController : ApiController
    {
        private NorthwindContext db = new NorthwindContext();

        // GET: api/Suppliers
        public IHttpActionResult GetSuppliers()
        {
            var suppliers = db.Suppliers.ToList();
            List<SuppliersView> suppliersView = suppliers.Select(s => new SuppliersView
            {
                Id = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                Phone = s.Phone,

            }).ToList();

            return Ok(suppliersView);
        }

        // GET: api/Suppliers/5
        [ResponseType(typeof(Suppliers))]
        public async Task<IHttpActionResult> GetSuppliers(int id)
        {
            Suppliers suppliers = await db.Suppliers.FindAsync(id);
            if (suppliers == null)
            {
                return BadRequest("No se ha encontrado el ID solicitado");
            }
            SuppliersView suppliersView = new SuppliersView() 
            {
                Id = suppliers.SupplierID,
                CompanyName = suppliers.CompanyName, 
                ContactName = suppliers.ContactName, 
                Phone = suppliers.Phone,
            };


            return Ok(suppliersView);
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuppliers(int id, Suppliers updatedSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actualSupplier = db.Suppliers.Find(id);

            if (actualSupplier == null)
            {
                return NotFound();
            }

            actualSupplier.CompanyName = updatedSupplier.CompanyName;
            actualSupplier.Phone = updatedSupplier.Phone;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(actualSupplier);
        }

        // POST: api/Suppliers
        [ResponseType(typeof(Suppliers))]
        public async Task<IHttpActionResult> PostSuppliers(Suppliers suppliers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suppliers.Add(suppliers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = suppliers.SupplierID }, suppliers);
        }

        // DELETE: api/Suppliers/5
        [ResponseType(typeof(Suppliers))]
        public async Task<IHttpActionResult> DeleteSuppliers(int id)
        {
            Suppliers suppliers = await db.Suppliers.FindAsync(id);
            if (suppliers == null)
            {
                return NotFound();
            }
            try
            {
                db.Suppliers.Remove(suppliers);
                await db.SaveChangesAsync();
            }
            catch
            {
                return BadRequest("No se puede ejecutar la accion debido a que eliminaría datos relacionados con otras tablas");
            }
            

            return Ok(suppliers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuppliersExists(int id)
        {
            return db.Suppliers.Count(e => e.SupplierID == id) > 0;
        }
    }
}