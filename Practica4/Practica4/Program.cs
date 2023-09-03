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
                Console.WriteLine("1 - Devolver Customer" +
                    "\n2 - Devolver todos los Productos sin stock" +
                    "\n3 - Devolver todos los Productos sin stock que cuesten más de 3 por unidad" +
                    "\n4 - Devolver todos los Customers de la Región WA" +
                    "\n5 - Devolver el primer elemento o nulo de una lista de Productos donde el ID del producto sea igual a 789" +
                    "\n6 - Devolver nombre de los Customers en Mayuscula y en Minuscula" +
                    "\n7 - Devolver Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997" +
                    "\n0 - Salir del programa");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1"://Punto 1
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
                    case "2"://Punto 2
                        Console.Clear();
                        Console.WriteLine("Query 2\nProductos sin Stock:");
                        var query2 = db.Products.Where(p => p.UnitsInStock == 0);
                        if (query2 != null)
                        {
                            foreach (var product in query2)
                            {
                                Console.WriteLine($"ID: {product.ProductID} | " +
                                    $"Nombre del Producto: {product.ProductName} | " +
                                    $"Nombre del Proveedor: {product.Suppliers.CompanyName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encuentran Productos sin Stock.");
                        }
                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
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
