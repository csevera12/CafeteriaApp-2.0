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
                if(inicioSesion.RegistrarUsuario())
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
        

        /* public  void HacerPedido(string fichero)
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
        }
        */

        public int MenuAdmin()
        {
            Console.WriteLine("MENÚ ADMIN");
            Console.WriteLine("1. Gestionar productos");
            Console.WriteLine("2. Cobrar pedidos");
            Console.WriteLine("3. Comprar productos");
            Console.WriteLine("4. Modificar productos");
            Console.WriteLine("Elige una opción:");
            string opcion = Console.ReadLine();
            int numeroOpcion = Convert.ToInt32(opcion);

            return numeroOpcion;
        }
        public int MenuCliente()
        {
            Console.WriteLine("MENÚ CLIENTE");
            Console.WriteLine("1. Comprar");
            Console.WriteLine("2. Reservar mesa");
            Console.WriteLine("Elige una opción:");
            string opcion = Console.ReadLine();
            int numeroOpcion = Convert.ToInt32(opcion);

            return numeroOpcion;
        }
    }
}