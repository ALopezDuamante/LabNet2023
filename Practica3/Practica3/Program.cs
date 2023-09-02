using Practica3.Entities;
using Practica3.Logic;
using System;
using System.Runtime.Remoting.Contexts;

namespace Practica3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcionmenu;
            string opcionconsulta;
            string opcionagregar;
            string opcioneliminar;
            string opcionactualizar;
            string menuprincipal = "Menu Principal\n\nSeleccione una opción:\n1 - Consultas\n2 - Agregar\n3 - Borrar\n4 - Actualizar\n0 - Salir";
            string opcionincorrecta = "Opcion incorrecta. Intentelo otra vez:";
            string menuconsulta = "Menu de Consultas\n\nSeleccione una opción:\n1 - Consultar Shippers\n2 - Consultar Suppliers \n0 - Volver al menú principal";
            string menuagregar = "Menu de Agregación\n\nSeleccione una opción:\n1 - Agregar Shipper\n2 - Agregar Supplier\n0 - Volver al menú principal";
            string menueliminar = "Menú de eliminación\n\nSeleccione una opción:\n1 - Eliminar Shipper\n2 - Eliminar Supplier\n0 - Volver al menú principal";
            string menuactualizar = "Menú de actualizaciones\n\nSeleccione una opción:\n1 - Actualizar Shipper\n2 - Actualizar Supplier\n0 - Volver al menú principal";
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            ShippersLogic shippersLogic = new ShippersLogic();
            Console.WriteLine(menuprincipal);
            opcionmenu = Console.ReadLine();
            while (opcionmenu != "0") 
            {
                Console.Clear();
                switch (opcionmenu){
                    case "1"://Consultas
                        Console.WriteLine(menuconsulta);
                        opcionconsulta = Console.ReadLine();
                        while(opcionconsulta != "0") 
                        {
                            if (opcionconsulta == "1")//Consulta Shippers
                            {
                                Console.Clear();
                                Console.WriteLine("Shippers:");
                                foreach (Shippers shipper in shippersLogic.GetAll())
                                {
                                    Console.WriteLine($"ID: {shipper.ShipperID} - " +
                                        $"Nombre de la Compañia: {shipper.CompanyName} - " +
                                        $"Telefono: {shipper.Phone}");

                                }
                            }
                            else if (opcionconsulta == "2")//Consulta Suppliers
                            {
                                Console.Clear();
                                Console.WriteLine("Suppliers:");
                                foreach (Suppliers supplier in suppliersLogic.GetAll())
                                {
                                    Console.WriteLine($"ID: {supplier.SupplierID} - " +
                                        $"Nombre de la Compañia: {supplier.CompanyName} - " +
                                        $"Nombre de Contacto: {supplier.ContactName}" +
                                        $"Telefono: {supplier.Phone}");
                                }

                            }
                            else
                            {
                                Console.WriteLine(opcionincorrecta);
                            }
                            Console.WriteLine("Presione Enter para volver al menu de consultas...");
                            Console.ReadLine();
                            Console.Clear() ;

                            Console.WriteLine(menuconsulta);
                            opcionconsulta = Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case "2"://Agregacion
                        Console.WriteLine(menuagregar);
                        opcionagregar = Console.ReadLine();
                        while (opcionagregar != "0")
                        {
                            if (opcionagregar == "1")//Agregar Shipper
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese nombre de compania");
                                string nuevonombre = Console.ReadLine();
                                Console.WriteLine("Ingrese telefono:");
                                string nuevotelefono = Console.ReadLine();
                                shippersLogic.Add(new Shippers { CompanyName = nuevonombre, Phone = nuevotelefono});

                            }
                            else if (opcionagregar == "2")//Agregar Supplier
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese nombre de compania");
                                string nuevonombre = Console.ReadLine();
                                Console.WriteLine("Ingrese telefono:");
                                string nuevotelefono = Console.ReadLine();
                                suppliersLogic.Add(new Suppliers { CompanyName = nuevonombre, Phone = nuevotelefono});

                            }
                            else
                            {
                                Console.WriteLine(opcionincorrecta);
                            }
                            Console.WriteLine("Presione Enter para volver al menú de agregación...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine(menuagregar);
                            opcionagregar = Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "3"://Eliminacion
                        Console.WriteLine(menueliminar);
                        opcioneliminar = Console.ReadLine();
                        while (opcioneliminar != "0")
                        {
                            if (opcioneliminar == "1")//Eliminar Shipper
                            {
                                Console.Clear();
                                Console.Write("Shippers:");
                                foreach (Shippers shippers in shippersLogic.GetAll())
                                {
                                    Console.WriteLine($"ID: {shippers.ShipperID} - " +
                                        $"Nombre de la Compañia: {shippers.CompanyName} - " +
                                        $"Telefono: {shippers.Phone}");
                                }
                                Console.WriteLine("Seleccione Id para eliminar Shipper o C para cancelar:");
                                var idEliminar = Console.ReadLine();
                                if (int.TryParse(idEliminar, out int num) && (idEliminar != "C"))
                                {
                                    Console.Clear();
                                    if (shippersLogic.GetById(num) != null)
                                    {
                                        Console.WriteLine("Se eliminará el siguiente Shipper:");
                                        Console.WriteLine($"Nombre de la Compañia: {shippersLogic.GetById(num).CompanyName} - Telefono: {shippersLogic.GetById(num).Phone}");
                                        Console.WriteLine("\nPresione 1 Para aceptar o 2 para cancelar:");
                                        var confirmar = Console.ReadLine();
                                        if (confirmar == "1")
                                        {
                                            shippersLogic.Delete(num);
                                            Console.WriteLine("Eliminación realizada");
                                        }
                                        else if (confirmar == "2")
                                        {
                                            Console.WriteLine("Operacion cancelada");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opcion incorrecta. Operacion cancelada");
                                        }

                                    }
                                    else if (idEliminar == "C")
                                    {
                                        Console.WriteLine("Operacion Cancelada");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Id inexistente");
                                    }
                                }
                                


                            }
                            else if (opcioneliminar == "2")//Eliminar Supplier
                            {
                                Console.Clear();
                                Console.WriteLine("Suppliers:");
                                foreach (Suppliers supplier in suppliersLogic.GetAll())
                                {
                                    Console.WriteLine($"ID: {supplier.SupplierID} - " +
                                        $"Nombre de la Compañia: {supplier.CompanyName} - " +
                                        $"Telefono: {supplier.Phone}");
                                }
                                Console.WriteLine("Seleccione Id para eliminar el Supplier o C para cancelar:");
                                var idEliminar = Console.ReadLine();
                                if (int.TryParse(idEliminar, out int num) && (idEliminar != "C"))
                                {
                                    Console.Clear();
                                    if (suppliersLogic.GetById(num) != null)
                                    {
                                        Console.WriteLine("Se eliminará el siguiente Supplier:");
                                        Console.WriteLine($"Nombre de la Compañia: {suppliersLogic.GetById(num).CompanyName} - Telefono: {suppliersLogic.GetById(num).Phone}");
                                        Console.WriteLine("\nPresione 1 Para aceptar:");
                                        var confirmar = Console.ReadLine();
                                        if (confirmar == "1")
                                        {
                                            suppliersLogic.Delete(num);
                                            Console.WriteLine("Eliminación realizada");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Eliminacion cancelada");
                                        }

                                    }
                                    else if (idEliminar == "C")
                                    {
                                        Console.WriteLine("Operacion Cancelada");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Id inexistente. Operacion cancelada");
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine(opcionincorrecta);
                            }
                            Console.WriteLine("Presione Enter para volver al menú de eliminación...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine(menueliminar);
                            opcioneliminar = Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "4"://Actualizar
                        Console.WriteLine(menuactualizar);
                        opcionactualizar = Console.ReadLine();
                        while (opcionactualizar != "0")
                        {
                            if (opcionactualizar == "1")//Actualizar Shipper
                            {
                                Console.Clear();
                                Console.WriteLine("Seleccione Supplier a actualizar ingresando su id o C para cancelar:");
                                foreach (Shippers shipper in shippersLogic.GetAll())
                                {
                                    Console.WriteLine($"ID: {shipper.ShipperID} - " +
                                        $"Nombre de la Compañia: {shipper.CompanyName} -" +
                                        $"Telefono: {shipper.Phone}");
                                }   

                                Console.WriteLine("Id:");
                                var actualizarShipper = Console.ReadLine();

                                if (int.TryParse(actualizarShipper, out int num) && (actualizarShipper != "C"))
                                {
                                    Console.WriteLine("Ingrese el nuevo nombre:");
                                    string nuevoNombre = Console.ReadLine();

                                    Console.Write("Ingrese el nuevo telefono");
                                    string nuevoTelefono = Console.ReadLine();
                                    shippersLogic.Update(new Shippers { ShipperID = num, CompanyName = nuevoNombre, Phone = nuevoTelefono });
                                }
                                else if(actualizarShipper == "C")
                                {
                                    Console.WriteLine("Operacion cancelada");
                                }
                                else
                                {
                                    Console.WriteLine("Opcion incorrecta. Operacion cancelada");
                                }

                            }
                            else if (opcionactualizar == "2")//Actualizar Supplier
                            {

                                Console.Clear();
                                Console.WriteLine("Suppliers:");
                                foreach (Suppliers supplier in suppliersLogic.GetAll())
                                {
                                    Console.WriteLine($"ID: {supplier.SupplierID} - " +
                                        $"Nombre de la Compañia: {supplier.CompanyName} - " +
                                        $"Telefono: {supplier.Phone}");
                                }

                                Console.WriteLine("Seleccion Id para actualizar Suppliers:");
                                var actualizarSupplier = Console.ReadLine();

                                if (int.TryParse(actualizarSupplier, out int num) && actualizarSupplier != "C")
                                {
                                    Console.WriteLine("Ingrese el nuevo nombre:");
                                    string nuevoNombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese el nuevo telefono:");
                                    string nuevoTelefono = Console.ReadLine();
                                    suppliersLogic.Update(new Suppliers { SupplierID = num, CompanyName = nuevoNombre, Phone = nuevoTelefono });
                                }
                                else if (actualizarSupplier == "C")
                                {
                                    Console.WriteLine("Operacion cancelada");
                                }
                                else
                                {
                                    Console.WriteLine("Opcion incorrecta. Operacion cancelada");
                                }

                            }
                            else
                            {
                                Console.WriteLine(opcionincorrecta);
                            }
                            Console.WriteLine("Presione Enter para volver al menú de agregación...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine(menuactualizar);
                            opcionactualizar = Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                }
                Console.Clear();
                Console.WriteLine(menuprincipal);
                opcionmenu = Console.ReadLine();
            }

        }
    }
}
