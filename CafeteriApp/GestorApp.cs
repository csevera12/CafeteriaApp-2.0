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
        InicioSesion inicioSesion;

        public GestorApp()
        {
            usuarios = new List<Usuario>();
            inicioSesion = new InicioSesion(usuarios);
            IniciarApp();
        }

        public void IniciarApp()
        {
            if (inicioSesion.ValidarCredenciales())
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