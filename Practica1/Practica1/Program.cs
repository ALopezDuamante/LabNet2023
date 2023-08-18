using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = 0;
            int o = 0;
            string cantidad;
            List<TransportePublico> lista = new List<TransportePublico>();
            System.Console.WriteLine("Seleccione el tipo de transporte para comenzar a cargar la cantidad de pasajeros:\n1- Taxi\n2-Omnibus");
            string tipo = Console.ReadLine();

            while (t < 5 || o < 5)
            {
                if (tipo == "1")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Ingrese la cantidad de pasajeros para el Taxi Nº{0}", i);
                        if (int.TryParse(Console.ReadLine(), out int num))
                        {
                            TransportePublico taxi = new Taxi(Convert.ToInt32(num));
                            lista.Add(taxi);
                            t++;
                        }
                    }
                    tipo = "2";
                }
                else if(tipo == "2")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Ingrese la cantidad de pasajeros para el Omnibus Nº{0}", i);
                        if (int.TryParse(Console.ReadLine(), out int num))
                        {
                            TransportePublico omnibus = new Omnibus(Convert.ToInt32(num));
                            lista.Add(omnibus);
                            o++;
                        }
                    }
                    tipo = "1";
                }
                else
                {
                    Console.WriteLine("¡Ingreso invalido! Intente nuevamente:");
                    tipo = Console.ReadLine();
                }
            }
                foreach (var transporte in lista)
                {
                    Console.WriteLine($"El numero de pasajeros es {transporte.Pasajeros}");
                }
                Console.WriteLine("termino");
                Console.ReadLine();
        }
    }
}
