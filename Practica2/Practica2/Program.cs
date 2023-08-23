using System;

namespace Practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Practica 2: Exceptions\n\n");

            Console.WriteLine("Ejercicio 1:\n");
            MetodosEx.Ejercicio1(9);

            Console.WriteLine("\nPresione Enter para continuar con el siguiente Ejercicio:");
            Console.ReadLine();

            Console.WriteLine("Ejercicio 2\n");
            MetodosEx.Ejercicio2();

            Console.WriteLine("\nPresione Enter para continuar con el siguiente Ejercicio:");
            Console.ReadLine();

            Console.WriteLine("Ejercicio 3:\n");

            try
            {
                Logic.Ejercicio3();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPresione Enter para continuar con el siguiente Ejercicio:");
            Console.ReadLine();

            Console.WriteLine("Ejercicio 4:\n");

            try
            {
                Logic.Ejercicio4();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
