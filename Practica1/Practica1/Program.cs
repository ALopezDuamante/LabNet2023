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
            List<TransportePublico> lista = new List<TransportePublico>();
            System.Console.WriteLine("Seleccione el tipo de transporte para comenzar a cargar la cantidad de pasajeros:\n1- Taxi\n2-Omnibus");
            string tipo = Console.ReadLine();

            while (t < 5 || o < 5)
            {
                if (tipo == "1")
                {
                    Console.WriteLine("\nIngresando pasajeros de Taxis...\n");
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.WriteLine("Ingrese la cantidad de pasajeros para el Taxi Nº{0}", i);
                        if (int.TryParse(Console.ReadLine(), out int num) && (num >= 0))
                        {
                            TransportePublico taxi = new Taxi(i, num);
                            lista.Add(taxi);
                            t++;
                        }
                        else
                        {
                            Console.WriteLine("¡Dato inválido! Intente nuevamente con un número válido\n");
                            i--;
                        }
                    }
                    Console.WriteLine("Todos los pasajeros de Taxi han sido ingresados...\n");
                    tipo = "2";
                }
                else if(tipo == "2")
                {
                    Console.WriteLine("\nIngresando pasajeros de Omnibus...\n");
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.WriteLine("Ingrese la cantidad de pasajeros para el Omnibus Nº{0}", i);
                        if (int.TryParse(Console.ReadLine(), out int num) && (num >= 0))
                        {
                            TransportePublico omnibus = new Omnibus(i, num);
                            lista.Add(omnibus);
                            o++;
                        }
                        else
                        {
                            Console.WriteLine("¡Dato inválido! Intente nuevamente con un número válido\n");
                            i--;
                        }
                    }
                    Console.WriteLine("Todos los pasajeros de Omnibus han sido ingresados...\n");
                    tipo = "1";
                }
                else
                {
                    Console.WriteLine("¡Ingreso invalido! Intente nuevamente:");
                    tipo = Console.ReadLine();
                }
            }
            Console.WriteLine("\nA continuacion se mostraran los transportes con sus respectiva cantidad de pasajeros...\n");
            foreach (var transporte in lista)
            {
                Console.WriteLine($"El numero de pasajeros del {transporte.GetType().Name} {transporte.Id} es: {transporte.Pasajeros}");
            }
                Console.ReadLine();
        }
    }
}
