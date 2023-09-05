using Practica4.Data;
using Practica4.Entities;
using System;
using System.ComponentModel;
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
                    "\n8 - Devolver los primeros 3 Customers de la Region WA" +
                    "\n9 - Devolver lista de Productos ordenados por Nombre | " +
                    "\n10 - Devolver lista de Prodcutos ordenados por UnitsInStock de mayor a menor" +
                    "\n11 - Devolver las Categorías asociadas a los Productos" +
                    "\n12 - Devolver el primer Producto de la lista | " +
                    "\n13 - Devolver los Customers con la cantidad de Ordenes asociadas" +
                    "\n0 - Salir del Programa");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1"://Punto 1
                        Console.Clear();
                        Console.WriteLine("Query 1\nIngrese ID del objeto Customer que desee mostrar (Formato 'AAAAA'):\n");
                        string traerCustomer = Console.ReadLine();

                        var query1 = db.Customers.FirstOrDefault(c => c.CustomerID == traerCustomer);

                        if (query1 != null)
                        {
                            Console.WriteLine($"ID: {query1.CustomerID} | Nombre: {query1.CompanyName}");
                        }
                        else
                        {
                            Console.WriteLine("Customer no encontrado. Tal vez ingresó un ID incorrecto.\nPresione Enter para volver al menú principal...");
                        }

                        Console.ReadLine();
                        break;

                    case "2"://Punto 2
                        Console.Clear();
                        Console.WriteLine("Query 2");

                        var query2 = db.Products.Where(p => p.UnitsInStock == 0);

                        if (query2 != null)
                        {
                            Console.WriteLine("\nProductos sin Stock:\n");
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
                            Console.WriteLine("\nProductos con Stock con valor de más de 3 por unidad:\n");
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
                            Console.WriteLine("\nCustomers de la Region WA:\n");
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
                        Console.Clear();
                        Console.WriteLine("Query 5");

                        var query5 = db.Products.FirstOrDefault(p => p.ProductID == 789);

                        if (query5 != null)
                        {
                            Console.WriteLine("\nProducto con ID = 789:\n");
                            Console.WriteLine($"Nombre del Producto: {query5.ProductName} | " +
                                $"Stock: {query5.UnitsInStock} | " +
                                $"Precio por Unidad: {query5.UnitPrice}");
                        }
                        else
                        {
                            Console.WriteLine("nulo");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "6"://Punto 6
                        Console.Clear();
                        Console.WriteLine("Query 6");

                        var query6 = from customer in db.Customers
                                     select customer;

                        if (query6 != null)
                        {
                            Console.WriteLine("\nNombre de los Customer en mayúcula y minúscula\n");
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

                    case "7"://Punto 7
                        Console.Clear();
                        Console.WriteLine("Query 7");

                        var query7 = from customer in db.Customers
                                     join order in db.Orders
                                     on customer.CustomerID equals order.CustomerID
                                     where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                                     select new { customerName = customer.CompanyName, customerPhone = customer.Phone, orderDate = order.OrderDate};

                        if (query7 != null)
                        {
                            Console.WriteLine("\nCustomers cuya Region es WA y la Fecha de Orden es mayor a 1/1/1997:\n");
                            foreach (var customer in query7)
                            {
                                Console.WriteLine($"Nombre de la Compañía: {customer.customerName} | " +
                                    $"Telefono: {customer.customerPhone} | "+
                                    $"Fecha de Orden: {customer.orderDate}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron Customers cuya Region sea WA y la Fecha de Orden sea mayor a 1/1/1997");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine ();
                        break;

                    case "8"://Punto 8
                        Console.Clear();
                        Console.WriteLine("Query 10");

                        var query8 = db.Customers.Where(c => c.Region == "WA").Take(3);

                        if (query8 != null)
                        {
                            foreach (var customer in query8)
                            {
                                Console.WriteLine($"ID: {customer.CustomerID} | " +
                                    $"Nombre de la Compañïa: {customer.CompanyName} | " +
                                    $"Region: {customer.Region}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron Customers cuya Region sea WA");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "9"://Punto 9
                        Console.Clear();
                        Console.WriteLine("Query 9");

                        var query9 = db.Products.OrderBy(p => p.ProductName).ToList();

                        if (query9 != null)
                        {
                            Console.WriteLine("\nLista de Productos ordenados por Nombre:\n");
                            foreach (var product in query9)
                            {
                                Console.WriteLine($"ID: {product.ProductID} | " +
                                    $"Nombre del Producto: {product.ProductName} | " +
                                    $"Unidades en Stock: {product.UnitsInStock}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se enconrtaron Productos en la Base de Datos");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "10"://Punto 10
                        Console.Clear();
                        Console.WriteLine("Query 10");

                        var query10 = (from product in db.Products
                                      orderby product.UnitsInStock descending
                                      select product).ToList();

                        if (query10 != null)
                        {
                            foreach (var product in query10)
                            {
                                Console.WriteLine($"ID: {product.ProductID} | " +
                                        $"Nombre del Producto: {product.ProductName} | " +
                                        $"Unidades en Stock: {product.UnitsInStock}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se enconrtaron Productos en la Base de Datos");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "11"://Punto 11
                        Console.Clear();
                        Console.WriteLine("Query 11");

                        var query11 = db.Products.Select(p => p.Categories).GroupBy(p => p.CategoryID).ToList();

                        if (query11!= null)
                        {
                            Console.WriteLine("\nLista de Categorias asociadas a Productos:\n");
                            foreach(var productCategory in query11)
                            {
                                Console.WriteLine($"ID del Prodcuto {productCategory.First().CategoryID} | " +
                                    $"ID de Categoria: {productCategory.First().CategoryName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay Categorias asociadas a Productos");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "12"://Punto 12
                        Console.Clear();
                        Console.WriteLine("Query 12");

                        var query12 = db.Products.First();

                        if (query12 != null)
                        {
                            Console.WriteLine("\nPrimer Producto de la lista:\n");
                            Console.WriteLine($"ID: {query12.ProductID} | " +
                                $"Nombre del Producto: {query12.ProductName} | " +
                                $"Unidades en Stock: {query12.UnitsInStock}");
                        }
                        else
                        {
                            Console.WriteLine("La lista está vacía");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "13"://Punto 13
                        Console.Clear();
                        Console.WriteLine("Query 13");

                        var query13 = db.Customers.Select(c => new { customer = c, orderCount = c.Orders.Count() }).ToList();

                        if (query13 != null)
                        {
                            Console.WriteLine("\nLista de Customers con su cantidad de Ordenes:\n");
                            foreach (var item in query13)
                            {
                                Console.WriteLine($"Customer ID: {item.customer.CustomerID} | " +
                                    $"Nombre de Compañía: {item.customer.CompanyName} | " +
                                    $"Cantidad de Ordenes: {item.orderCount}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encontraron datos\n");
                        }

                        Console.WriteLine("\nPresione Enter para volver al menú principal...");
                        Console.ReadLine();
                        break;

                    case "0":

                        Console.Clear() ;
                        Console.WriteLine("Saliendo del programa.");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion no válida. Presione Enter para volver a intentar...");
                        Console.ReadLine() ;
                        break;
                }

            } while (opcion != "0");

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
