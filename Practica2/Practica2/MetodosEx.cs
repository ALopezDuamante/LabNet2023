using System;

namespace Practica2
{
    public class MetodosEx
    {

        public static void Ejercicio1(int dividendo)
        {
            try
            {
                int resultado = dividendo / 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Terminó la operación");
            }

        }

        public static void Ejercicio2()
        {
            try
            {
                Console.WriteLine("Ingrese un dividendo y luego un divisor:");
                string dividendo = Console.ReadLine();
                string divisor = Console.ReadLine();
                int resultado = 0;
                if (int.TryParse(dividendo, out int num1) && int.TryParse(divisor, out int num2))
                {
                    resultado = num1 / num2;
                }
                else
                {
                    throw new Exception();
                }

                Console.WriteLine($"El resultado de la división es: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message + "¡Solo Chuck Norris divide por cero!");
            }
            catch (Exception)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }
        }
    }
}
