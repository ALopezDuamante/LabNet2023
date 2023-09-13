using Practica7.Data;

namespace Practica7.Logic
{
    public abstract class BaseLogic
    {
        protected readonly NorthwindContext context;

        protected BaseLogic()
        {
            context = new NorthwindContext();
        }
    }
}
