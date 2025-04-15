using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class GestorApp
    {
        InicioSesion inicioSesion;
        List<Usuario> usuarios;

        public GestorApp()
        {
            usuarios = new List<Usuario>();
            IniciarApp();
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

            Console.WriteLine("Introduce tu correo :");
            string correo = Console.ReadLine();

            //Poner permisos de administrador o cliente
            //Hacer en usuario un constructor sin el atributo permisos

            Console.WriteLine("Las contraseñas coinciden, se ha registrado correctamente.");
            usuarios.Add(new Cliente(usuario, password));

            IniciarApp();

            return user;
        }
        public void IniciarApp()
        {
            inicioSesion = new InicioSesion();

            if (inicioSesion.ValidarCredenciales(usuarios))
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
