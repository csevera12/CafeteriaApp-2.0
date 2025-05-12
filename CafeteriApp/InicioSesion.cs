using System;
using System.Collections.Generic;

namespace CaferiApp
{
    public class InicioSesion
    {
        private List<Usuario> usuarios;

        public InicioSesion(List<Usuario> usuarios)
        {
            this.usuarios = usuarios;
        }

        public bool ValidarCredenciales()
        {
            Console.WriteLine("Usuario: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Contraseña: ");
            string contrasena = Console.ReadLine();

            foreach (Usuario usuario in usuarios)
            {
                if (nombre == usuario.Nombre && contrasena == usuario.Contrasena)
                {
                    Console.WriteLine("BIENVENIDO " + nombre + " !");
                    return true;
                }
            }

            Console.WriteLine("No estás registrado! - ¿Deseas registrarte (S/N)? ");
            string opcion = Console.ReadLine();

            if (opcion?.ToUpper() == "S")
            {
                RegistrarUsuario(nombre, contrasena);
                return true;
            }
            else
            {
                Console.WriteLine("Saliendo de la aplicación...");
                return false;
            }
        }

        private void RegistrarUsuario(string nombre, string contrasena)
        {
            Console.WriteLine("Introduce tu teléfono:");
            long telefono = Convert.ToInt64(Console.ReadLine());

            usuarios.Add(new Cliente("C", nombre, contrasena, telefono));
            Console.WriteLine("Usuario registrado correctamente.");
        }
    }
}
