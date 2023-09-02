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
            //Falta lograr eliminar Order Detail para que se pueda eliminar el Supplier
            var objetoEliminar = context.Suppliers.Find(id);
            if (objetoEliminar != null)
            {
                context.Products.RemoveRange(objetoEliminar.Products);
                context.Suppliers.Remove(objetoEliminar);
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
