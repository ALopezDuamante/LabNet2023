using Practica4.Data;
using System;
using System.Linq;


namespace Practica4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindContext();
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal\n\nSeleccione una opción:\n");
                Console.WriteLine("1 - Query 1\n2 - Query 2\n3 - Query 3\n4 - Query 4\n5 - Query 5\n6 - Query 6\n7 - Query 7\n0 - Salir del programa");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1"://Query 1
                        Console.Clear();
                        Console.WriteLine("Query 1\nIngrese ID del objeto Customer que desee mostrar:");
                        string traerCustomerId = Console.ReadLine();
                        var query1 = db.Customers.Where(c => c.CustomerID == traerCustomerId).FirstOrDefault();

                        if (query1 != null)
                        {
                            Console.WriteLine($"ID: {query1.CustomerID} | Nombre: {query1.CompanyName}");
                        }
                        else
                        {
                            Console.WriteLine("Customer no encontrado. Tal vez ingresó un ID incorrecto.\nPresione Enter para volver al menú principal...");
                            Console.ReadLine();
                        }
                       
                        break;
                    case "2"://Query 2
                        Console.Clear();
                        Console.WriteLine("Query 2");
                        break;
                    case "3":
                        Console.WriteLine("Query 3");
                        break;
                    case "4":
                        Console.WriteLine("Query 4");
                        break;
                    case "5":
                        Console.WriteLine("Query 5");
                        break;
                    case "6":
                        Console.WriteLine("Query 6");
                        break;
                    case "7":
                        Console.WriteLine("Query 7");
                        break;
                    case "0":
                        Console.Clear() ;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion no válida. Presione Enter para volver a intentar...");
                        Console.ReadLine() ;
                        break;
                }

            } while (opcion != "0");

                

            //var queryEjemplo = from region in db.Region
            //            orderby region.RegionID descending
            //            select region;

            //foreach (var item in queryEjemplo)
            //{
            //    Console.WriteLine($"{item.RegionID}");
            //}
            Console.ReadLine();
        }
    }
}
