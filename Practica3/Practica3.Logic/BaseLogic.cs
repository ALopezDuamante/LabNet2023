using Practica3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.Logic
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
