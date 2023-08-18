using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Omnibus : TransportePublico
    {
        public Omnibus(int _id, int _pasajeros) : base(_id, _pasajeros)
        {
        }

        public override void Avanzar()
        {
            Console.WriteLine("Avanzando...");
        }

        public override void Detenerse()
        {
            Console.WriteLine("Deteniendose...");
        }

    }
}
