using Practica3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.Logic
{
    public class OrdersLogic : BaseLogic, IBaseLogic<Orders>
    {
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public void Add(Orders newObject)
        {
            context.Orders.Add(newObject);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderDetailEliminar = context.Order_Details.Where(od => od.OrderID == id);
            context.Order_Details.RemoveRange(orderDetailEliminar);
            var objetoEliminar = context.Orders.Find(id);
            context.Orders.Remove(objetoEliminar);
            SuppliersLogic supplier = new SuppliersLogic();
            context.SaveChanges();
        }

        public void Update(Orders updateObject)
        {
            throw new NotImplementedException();
        }

        public Orders GetById(int id)
        {
            return context.Orders.Find(id);
        }
    }
}
