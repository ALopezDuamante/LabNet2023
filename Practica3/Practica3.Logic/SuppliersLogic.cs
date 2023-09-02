using Practica3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Practica3.Logic
{
    public class SuppliersLogic : BaseLogic, IBaseLogic<Suppliers>
    {
        public List<Suppliers> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public void Add(Suppliers newObject)
        {
            context.Suppliers.Add(newObject);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var eliminarSupplier = context.Suppliers.Find(id);
            if (eliminarSupplier != null)
            {
                var eliminarProduct = context.Products.Where(p => p.SupplierID == id).ToList();

                foreach (var product in eliminarProduct)
                {
                    context.Order_Details.RemoveRange(product.Order_Details);
                    context.Products.Remove(product);
                }
                context.SaveChanges();

                context.Suppliers.Remove(eliminarSupplier);
            }

            context.SaveChanges();

        }

        public void Update(Suppliers updateObject)
        {
            var actualizarsupplier = context.Suppliers.Find(updateObject.SupplierID);
            actualizarsupplier.CompanyName = updateObject.CompanyName;
            actualizarsupplier.Phone = updateObject.Phone;

            context.SaveChanges();
        }

        public Suppliers GetById(int id)
        {
            return context.Suppliers.Find(id);
        }
    }
}
