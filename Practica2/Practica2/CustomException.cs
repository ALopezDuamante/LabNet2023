using System;

namespace Practica2
{
    internal class CustomException : Exception
    {
        public CustomException(string mensaje) : base(mensaje) { }

        public override string Message
        {
            get
            {
                return "Sobrecarga de Mensaje: " + base.Message;
            }
        }
    }
}
