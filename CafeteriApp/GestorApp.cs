using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class GestorApp
    {
        List<Usuario> usuarios;
        public GestorApp()
        {
            usuarios = new List<Usuario>();
            IniciarApp();
        }
        public bool ValidarCredenciales(List<Usuario> usuarios)
        {
            bool esValido = false;
            bool salir = false;

            Console.WriteLine("Usuario: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Contraseña: ");
            string contrasena = Console.ReadLine(); 

            foreach (Usuario usuario in usuarios)
            {
                if (nombre == usuario.Nombre  && contrasena == usuario.Contrasena)
                {
                    Console.WriteLine("BIENVENIDO " + nombre + " !");
                    esValido = true;
                    IniciarApp();
                }
                else
                {
                    Usuario u = new Usuario();

                    Console.WriteLine("No estás registrado ! - Deseas registrarte (S/N) ? ");
                    string opcion = Console.ReadLine();

                    if (opcion == "S")
                    {
                        int telefono = 0;

                        RegistrarUsuarios();
                        u = new Cliente("C",nombre, contrasena,telefono);
                        Console.WriteLine("Usuario registrado correctamente !");
                    }
                    else if (opcion == "N")
                    {
                        Console.WriteLine("No estás registrado");
                        Console.WriteLine("Saliendo de la aplicación...");
                        salir = true;
                    }
                }
            }      
            return esValido;
        }
        public Usuario RegistrarUsuarios()
        {
            Usuario user = new Usuario();

            Console.WriteLine("Introduce tu usuario :");
            string usuario = Console.ReadLine();

            Console.WriteLine("Introduce tu contraseña :");
            string password = Console.ReadLine();

            Console.WriteLine("Confirma tu contraseña :");
            string password2 = Console.ReadLine();

            while (password2 != password)
            {
                Console.WriteLine("Las contraseñas no coinciden");
            }
            Console.WriteLine("Introduce tu telefono :");
            int telefono = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Las contraseñas coinciden, se ha registrado correctamente.");
            usuarios.Add(new Cliente("C",usuario, password, telefono));

            return user;
        }
        public void IniciarApp()
        {
            if (ValidarCredenciales(usuarios))
            {
                Console.WriteLine("Bienvenido a la aplicación de cafetería.");
            }
            else
            {
                Console.WriteLine("No se pudo iniciar sesión. Saliendo de la aplicación.");
            }
        }
    }
}
