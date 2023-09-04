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
                    "\n3 - Devolver todos los Productos con stock que cuesten más de 3 por unidad" +
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
                        Console.WriteLine("Query 2");

                        var query2 = db.Products.Where(p => p.UnitsInStock == 0);

                        if (query2 != null)
                        {
                            Console.WriteLine("\nProductos sin Stock:");
                            foreach (var product in query2)
                            {
                                Console.WriteLine($"ID: {product.ProductID} | " +
                                    $"Nombre del Producto: {product.ProductName} | " +
                                    $"Nombre del Proveedor: {product.Suppliers.CompanyName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encuentran Productos sin Stock.");
                        }
                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "3"://Punto 3
                        Console.Clear();
                        Console.WriteLine("Query 3");

                        var query3 = from product in db.Products
                                     where product.UnitsInStock > 0 && product.UnitPrice > 3
                                     select product;

                        if (query3 != null)
                        {
                            Console.WriteLine("\nProductos con Stock con valor de más de 3 por unidad:");
                            foreach (var product in query3)
                            {
                                Console.WriteLine($"ID: {product.ProductID} | " +
                                       $"Nombre del Producto: {product.ProductName} | " +
                                       $"Unidades en Stock: {product.UnitsInStock} | " +
                                       $"Precio por Unidad: {product.UnitPrice}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encontraron Productos con Stock cuyo valor sea de más de 3 por Unidad");
                        }
                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "4"://Punto 4
                        Console.Clear();
                        Console.WriteLine("Query 4");

                        var query4 = db.Customers.Where(c => c.Region == "WA");

                        if (query4 != null)
                        {
                            Console.WriteLine("\nCustomers de la Region WA:");
                            foreach (var customer in query4)
                            {
                                Console.WriteLine($"Id: {customer.CustomerID} | " +
                                    $"Nombre de la Compañía: {customer.CompanyName} | " +
                                    $"Nombre del Contacto: {customer.ContactName} |" +
                                    $"Telefono: {customer.Phone}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encontraron Customers de la Region WA");
                        }
                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "5"://Punto 5
                        Console.WriteLine("Query 5");
                        break;

                    case "6"://Punto 6
                        Console.Clear();
                        Console.WriteLine("Query 6");

                        var query6 = from customer in db.Customers
                                     select customer;

                        if (query6 != null)
                        {
                            Console.WriteLine("Nombre de los Customer en mayúcula y minúscula");
                            foreach (var customer in query6)
                            {
                                Console.WriteLine($"Nombre en Mayúscula: {customer.CompanyName.ToUpper()} | " +
                                    $"Nombre en Minúscula: {customer.CompanyName.ToLower()}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron Customers para mostrar");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "7"://Punto
                        Console.Clear();
                        Console.WriteLine("Query 7");

                        var query7 = from customer in db.Customers
                                     join order in db.Orders
                                     on customer.CustomerID equals order.CustomerID
                                     where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                                     select new { customerName = customer.CompanyName, customerPhone = customer.Phone, orderDate = order.OrderDate};

                        if (query7 != null)
                        {
                            Console.WriteLine("\nCustomers cuya Region es WA y la Fecha de Orden es mayor a 1/1/1997:");
                            foreach (var item in query7)
                            {
                                Console.WriteLine($"Nombre de la Compañía: {item.customerName} | " +
                                    $"Telefono: {item.customerPhone} | "+
                                    $"Fecha de Orden: {item.orderDate}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron Customers cuya Region sea WA y la Fecha de Orden sea mayor a 1/1/1997");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine ();
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

            Console.ReadLine();
        }
    }
}
