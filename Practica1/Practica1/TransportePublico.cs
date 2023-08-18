using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public abstract class TransportePublico
    {
        private int _pasajeros;

        public TransportePublico(int _pasajeros) 
        {
            this._pasajeros = _pasajeros;
        }

        public int Pasajeros
        {
            set { this._pasajeros = value; }
            get { return _pasajeros; }
        }
        public abstract void Avanzar();

        public abstract void Detenerse();



    }
}
