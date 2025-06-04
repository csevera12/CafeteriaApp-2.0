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

        static List<Producto> productosDisponibles;
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
                this.cliente = (Cliente)usuario;
            }
            else if(usuario is Administrador)
            {
                this.admin = (Administrador)usuario;
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
                usuario = inicioSesion.ValidarCredenciales();
            }

            if (usuario != null)
            {
                Console.WriteLine("Bienvenido a la aplicación de cafetería, " + usuario.Nombre);
            }
            else
            {
                Console.WriteLine("Error: no se pudo iniciar sesión o registrar.");
            }
        }
        public void MenuAdministrador()
        {

        }

        public  void HacerPedido(string fichero)
        {
            Pedido p;
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

            p = new Pedido(pedido);

            foreach(Producto prod in p.Productos)
            {
                precioTotal += prod.Precio;

            }
            Console.WriteLine($"El precio total del pedido es :{precioTotal}");
        }

        public void MenuC(string opcion)
        {
            bool salir = false;

            while (!salir)
            {
                switch (opcion)
                {
                    case "1":
                        HacerPedido("productos.txt");
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "S":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta, inténtalo de nuevo ");
                        break;
                }
            }
        }

        public int MenuCliente()
        {
            Console.WriteLine("MENÚ CLIENTE");
            Console.WriteLine("1. Comprar");
            Console.WriteLine("2. Reservar mesa");
            Console.WriteLine("Elige una opción:");
            string opcion = Console.ReadLine();
            int numeroOpcion = Convert.ToInt32(opcion);

            MenuC(opcion);

            return numeroOpcion;
        }
    }
}