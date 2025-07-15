using BaseDatos.Clases;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MostrarMenu();
        }


        public static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine("=============CRUD CLIENTES==========================");
                Console.WriteLine("====================================================");
                Console.WriteLine("1. Create Cliente");
                Console.WriteLine("2. Read Cliente");
                Console.WriteLine("3. Read all Clientes");
                Console.WriteLine("4. Update Cliente");
                Console.WriteLine("5. Delete Cliente");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================================");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        createCliente();
                        break;
                    case "2":
                        ReadCliente();
                        break;
                    case "3":
                        ReadAllCliente();
                        break;
                    case "4":
                        UpdateCliente();
                        break;
                    case "5":
                        DeleteCliente();
                        break;
                    case "6":
                        return; // Salir del menú
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        Console.ReadLine();
                        break;

                }
            }
        }

        private static void DeleteCliente()
        {
            Console.Clear();
            Console.WriteLine("***********DELETE CLIENTE****************");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente a eliminar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                Console.WriteLine($"Estas seguro que desea elimimar este cliente: {objClienteBuscado.getNombresCompletos()} ? (S/N)");
                string confirmacion = Console.ReadLine().ToUpper();
                if (confirmacion == "S")
                {
                    BaseDatos.BaseDeDatos.BaseDatosCliente.Remove(objClienteBuscado);
                    Console.WriteLine("Cliente eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadLine();
        }

        private static void UpdateCliente()
        {
            Console.Clear();
            Console.WriteLine("************ UPDATE CLIENTES*************");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente a actualizar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                objClienteBuscado.imprimir();
                Console.WriteLine();
                Console.Write("Ingrese el nombre del cliente: ");
                string nombre = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese el apellido del cliente: ");
                string apellido = Console.ReadLine();
                Console.WriteLine();
                objClienteBuscado.setNombres(nombre);
                objClienteBuscado.setApellidos(apellido);
                BaseDatos.BaseDeDatos.BaseDatosCliente.RemoveAt(objClienteBuscado.getId() - 1); // Eliminar el cliente existente
                BaseDatos.BaseDeDatos.BaseDatosCliente.Insert(objClienteBuscado.getId() - 1, objClienteBuscado); // Insertar el cliente actualizado
                Console.WriteLine("Cliente actualizado con éxito!");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadLine();
        }

        private static void ReadAllCliente()
        {
            Console.Clear();
            Console.WriteLine("************READ ALL CLIENTES*************");
            Console.WriteLine();
            BaseDatos.BaseDeDatos.ImprimirClientes();
            Console.ReadLine();
        }

        private static void ReadCliente()
        {
            Console.Clear();
            Console.WriteLine("*READ CLIENTE*");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente a buscar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                objClienteBuscado.imprimir();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadLine();
        }
        

        private static void createCliente()
        {
            Console.Clear();
            Console.WriteLine("*********** CREATE CLIENTE **************");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente: ");
            string cedula = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ingrese el apellido del cliente: ");
            string apellido = Console.ReadLine();
            Console.WriteLine();

            Cliente objCliente = new Cliente(cedula, nombre, apellido);
            Console.WriteLine("Cliente creado con exito.");
            Console.ReadLine();
        }
    }
}