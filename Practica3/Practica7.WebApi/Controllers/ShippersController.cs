using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Practica7.WebApi.Data;
using Practica7.WebApi.Models;

namespace Practica7.WebApi.Controllers
{
    public class ShippersController : ApiController
    {
        private NorthwindContext db = new NorthwindContext();

        // GET: api/Shippers
        public IHttpActionResult GetShippers()
        {
            var shippers = db.Shippers.ToList();
            List<ShippersView> shippersView = shippers.Select(s => new ShippersView
            {
                Id = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();

            return Ok(shippersView);
        }

        // GET: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public async Task<IHttpActionResult> GetShippers(int id)
        {
            Shippers shippers = await db.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return BadRequest("No se ha encontrado el ID solicitado"); ;
            }

            ShippersView shippersView = new ShippersView()
            {
                Id = shippers.ShipperID,
                CompanyName = shippers.CompanyName,
                Phone = shippers.Phone,
            };

            return Ok(shippersView);
        }

        // PUT: api/Shippers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShipper(int id, Shippers updatedShipper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actualShipper = db.Shippers.Find(id);

            if (actualShipper == null)
            {
                return NotFound();
            }

            actualShipper.CompanyName = updatedShipper.CompanyName;
            actualShipper.Phone = updatedShipper.Phone;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(actualShipper);
        }

        // POST: api/Shippers
        [ResponseType(typeof(Shippers))]
        public async Task<IHttpActionResult> PostShippers(Shippers shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shippers.Add(shippers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shippers.ShipperID }, shippers);
        }

        // DELETE: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public async Task<IHttpActionResult> DeleteShippers(int id)
        {
            Shippers shippers = await db.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return NotFound();
            }

            try
            {
                db.Shippers.Remove(shippers);
                await db.SaveChangesAsync();
            }
            catch
            {
                return BadRequest("No se puede ejecutar la accion debido a que eliminaría datos relacionados con otras tablas");
            }

            return Ok(shippers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShippersExists(int id)
        {
            return db.Shippers.Count(e => e.ShipperID == id) > 0;
        }
    }
}