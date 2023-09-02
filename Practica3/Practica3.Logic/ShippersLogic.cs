using Practica3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica3.Logic
{
    public class ShippersLogic : BaseLogic, IBaseLogic<Shippers>
    {
        public void Add(Shippers newObject)
        {
            context.Shippers.Add(newObject);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var objetoEliminar = context.Shippers.Find(id);
            context.Shippers.Remove(objetoEliminar);
            

            context.SaveChanges();
        }

        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public Shippers GetById(int id)
        {
            return context.Shippers.Find(id);
        }

        public void Update(Shippers updateObject)
        {
            var actualizarshipper = context.Shippers.Find(updateObject.ShipperID);
            if (actualizarshipper != null)
            {
                actualizarshipper.CompanyName = updateObject.CompanyName;
                actualizarshipper.Phone = updateObject.Phone;
            }

            context.SaveChanges();
        }
    }
}
