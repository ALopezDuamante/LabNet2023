using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.Logic
{
    internal interface IBaseLogic<T>
    {
        T GetById(int id);
        List<T> GetAll();

        void Add(T newObject);

        void Delete(int id);

        void Update(T updateObject);
    }
}
