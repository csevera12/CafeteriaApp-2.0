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
        public void RegistrarUsuarios(Usuario user)
        {
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
        }
        public void IniciarApp()
        {
            inicioSesion = new InicioSesion();
            //inicioSesion.IniciarSesion();
            if (inicioSesion.ValidarCredenciales(usuarios))
            {
                Console.WriteLine("Bienvenido a la aplicación de cafetería.");
                // Aquí puedes agregar más lógica para la aplicación después de iniciar sesión.
            }
            else
            {
                Console.WriteLine("No se pudo iniciar sesión. Saliendo de la aplicación.");
            }
        }
    }
}
