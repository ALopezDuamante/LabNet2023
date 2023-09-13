using System.Collections.Generic;

namespace Practica7.Logic
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
