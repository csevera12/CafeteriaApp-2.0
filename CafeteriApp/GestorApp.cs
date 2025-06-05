using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class GestorApp
    {
        List<Usuario> usuarios;
        InicioSesion inicioSesion;

        Cliente cliente;
        Administrador admin;

        static List<Producto> productos;
        int opcionSeleccionada = 0; // 0 para iniciar sesión, 1 para registro


        public GestorApp(List<Usuario> usuarios, int opcionSeleccionada)
        {
            this.usuarios = usuarios;
            this.opcionSeleccionada = opcionSeleccionada;
            inicioSesion = new InicioSesion(this.usuarios);
        }

        public GestorApp()
        {

        }
        public GestorApp(Usuario usuario)
        {
            if (usuario is Cliente)
            {
                usuario = (Cliente)usuario;
            }
            else if (usuario is Administrador)
            {
                usuario = (Administrador)usuario;
            }
        }


        public void IniciarApp()
        {
            Usuario usuario = null;

            if (opcionSeleccionada == 0) // Iniciar sesión
            {
                usuario = inicioSesion.ValidarCredenciales();
            }
            else if (opcionSeleccionada == 1) // Registro
            {
                if (inicioSesion.RegistrarUsuario())
                {
                    Console.WriteLine("Registro exitoso. Por favor, inicie sesión.");
                    usuario = inicioSesion.ValidarCredenciales();
                }
                else
                {
                    Console.WriteLine("Error al registrar el usuario. Inténtelo de nuevo.");
                }
            }
        }


        /* public static void HacerPedido(string fichero)
        {
            // Pedido p;
            string pedido = " ";
            double precioTotal = 0;

            string[] partes = File.ReadAllLines(fichero);

            int selectedIndex = 0;

            Console.Clear();
            Console.WriteLine("Seleccione una opción con las flechas y presione Enter:");

            for(int i = 0;i<productosDisponibles.Count;i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(partes[i]);
            }
            ConsoleKeyInfo tecla = Console.ReadKey(true);

            do
            {
                for (int i = 0; i < productosDisponibles.Count; i++)
                {
                    if (i == selectedIndex && tecla.Key == ConsoleKey.UpArrow || tecla.Key == ConsoleKey.DownArrow)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        if (tecla.Equals(ConsoleKey.Enter))
                        {
                            Console.WriteLine($"Has seleccionado : {pedido}");
                        }
                    }
                }
            } while (tecla.Key != ConsoleKey.Enter);

            // p = new Pedido(pedido);

            foreach(Producto prod in p.Productos)
            {
                precioTotal += prod.Precio;

            }
            Console.WriteLine($"El precio total del pedido es :{precioTotal}");
        }*/


        public static string CentrarTexto(string texto, int anchoPantalla)
        {
            int espacios = (anchoPantalla - texto.Length) / 2;

            return espacios > 0 ? new string(' ', espacios) + texto : texto;
        }
        public static void OptCliente()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            string opcion = "";
            while (opcion != "S")
            {
                opcion = GestorApp.MenuCliente();
                switch (opcion)
                {
                    case "1":
                        //GestorApp.HacerPedido("productos.txt");
                        break;
                    case "2":
                        //GestorApp.VerPedidos();
                        break;
                    case "S":
                        Console.WriteLine(CentrarTexto("Saliendo de la aplicación...", anchoPantalla));
                        break;
                    default:
                        Console.WriteLine(CentrarTexto("Opción no válida. Inténtalo de nuevo.", anchoPantalla));
                        break;
                }
                Console.WriteLine();
            }
        }
        public static void OptAdmin()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            string opcion = "";
            while (opcion != "S")
            {
                opcion = GestorApp.MenuAdmin();
                switch (opcion)
                {
                    case "1":
                        CrearProducto();
                        break;
                    case "2":
                        EliminarProducto();
                        break;
                    case "3":
                        VerPedidosYCobrar();
                        break;
                    case "4":
                        //AñadirStock();
                        break;
                    case "5":
                        //ModificarProducto();
                        break;
                    case "6":
                        VerProductos();
                        break;
                    case "S":
                        Console.WriteLine(CentrarTexto("Saliendo de la aplicación...", anchoPantalla));
                        break;
                    default:
                        Console.WriteLine(CentrarTexto("Opción no válida. Inténtalo de nuevo.", anchoPantalla));
                        break;
                }
                Console.WriteLine();
            }
        }
        public static string MenuAdmin()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            Console.WriteLine(CentrarTexto("MENÚ ADMIN", anchoPantalla));
            Console.WriteLine(CentrarTexto("1.-Crear producto", anchoPantalla));
            Console.WriteLine(CentrarTexto("2.-Eliminar producto", anchoPantalla));
            Console.WriteLine(CentrarTexto("3.-Ver pedidos y cobrarlos", anchoPantalla));
            Console.WriteLine(CentrarTexto("4.-Añadir productos al stock", anchoPantalla));
            Console.WriteLine(CentrarTexto("5.-Modificar producto", anchoPantalla));
            Console.WriteLine(CentrarTexto("6.-Ver productos", anchoPantalla));
            Console.WriteLine(CentrarTexto("S.-Salir", anchoPantalla));
            Console.Write(CentrarTexto("Elige una opción:", anchoPantalla));
            string opcion = Console.ReadLine();

            return opcion;
        }
        public static string MenuCliente()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            Console.WriteLine(CentrarTexto("MENÚ CLIENTE", anchoPantalla));
            Console.WriteLine(CentrarTexto("1.-Hacer pedido", anchoPantalla));
            Console.WriteLine(CentrarTexto("2.-Reservar mesa", anchoPantalla));
            Console.WriteLine(CentrarTexto("S.-Salir", anchoPantalla));
            Console.Write(CentrarTexto("Elige una opción:", anchoPantalla));
            string opcion = Console.ReadLine();


            return opcion;
        }
        public static void VerProductos()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            productos = Producto.CargarProductos("productos.txt");
            Console.WriteLine();
            Console.WriteLine(CentrarTexto("Productos disponibles:", anchoPantalla));
            Console.WriteLine(CentrarTexto("Código\tNombre\tTipo\tPrecio\tStock", anchoPantalla));
            foreach (Producto producto in productos)
            {
                Console.WriteLine(CentrarTexto(producto.ToString(), anchoPantalla));
            }

        }
        public static void CrearProducto()
        {
            productos = Producto.CargarProductos("productos.txt");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Tipo (salado, dulce, bebida): ");
            string tipo = Console.ReadLine().ToLower();

            Console.Write("Precio: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            Producto nuevo = null;

            if (tipo == "salado")
            {
                nuevo = new Salado(codigo, nombre, tipo, precio, stock);
            }
            else if (tipo == "dulce")
            {
                nuevo = new Dulce(codigo, nombre, tipo, precio, stock);
            }
            else if (tipo == "bebida")
            {
                nuevo = new Bebida(codigo, nombre, tipo, precio, stock);
            }

            if (nuevo != null)
            {
                productos.Add(nuevo);
                Console.WriteLine("Producto creado correctamente.");
                Producto.GuardarProductos("productos.txt", productos);
            }
            else
            {
                Console.WriteLine("Tipo de producto no válido.");
            }
        }
        public static void EliminarProducto()
        {
            productos = Producto.CargarProductos("productos.txt");
            Console.Write("Introduce el código del producto a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto productoAEliminar = productos.Find(p => p.Codigo == codigo);

            if (productoAEliminar != null)
            {
                productos.Remove(productoAEliminar);
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Producto.GuardarProductos("productos.txt", productos);
        }

        public static void VerPedidosYCobrar()
        {
            string rutaTxt = "pedidos.txt";

            List<string> pedidos = File.ReadAllLines(rutaTxt).ToList();

            if (pedidos.Count == 0)
            {
                Console.WriteLine("En estos momentos no hay pedidos");
            }

            Console.WriteLine("PEDIDOS: ");

            for (int i = 0; i < pedidos.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {pedidos[i]}.");
            }

            Console.WriteLine("Introduce el número de pedido a cobrar: ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion > 0 && opcion <= pedidos.Count)
            {
                pedidos.RemoveAt(opcion - 1);

                File.WriteAllLines(rutaTxt, pedidos);

                Console.WriteLine("Pedido cobrado y eliminado");
            }
            
        }

    }
}