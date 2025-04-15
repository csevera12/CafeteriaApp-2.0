using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class InicioSesion
    {
        string nombre;
        string contrasena;

        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public InicioSesion(string usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;
        }

        public InicioSesion()
        {

        }

        public bool ValidarCredenciales(List<Usuario> usuarios)
        {
            GestorApp ga = new GestorApp();
            bool esValido = false;
            bool salir = false;

            Console.WriteLine("Usuario: ");
            nombre = Console.ReadLine();

            Console.WriteLine("Contraseña: ");
            contrasena = Console.ReadLine(); 

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contrasena == contrasena)
                {
                    Console.WriteLine("BIENVENIDO " + nombre + " !");
                    esValido = true;
                    ga.IniciarApp();
                }
                else
                {
                    Usuario u = new Usuario();

                    Console.WriteLine("No estás registrado ! - Deseas registrarte (S/N) ? ");
                    string opcion = Console.ReadLine();

                    if (opcion == "S")
                    {
                        ga.RegistrarUsuarios();
                        u = new Cliente(nombre, contrasena);
                        Console.WriteLine("Usuario registrado correctamente !");
                    }
                    else if (opcion == "N")
                    {
                        Console.WriteLine("No estás registrado");
                        salir = true;
                    }
                }
            }      
            return esValido;
        }
    }
}
