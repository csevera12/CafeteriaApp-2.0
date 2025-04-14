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
            bool esValido = false;

            Console.WriteLine("Usuario: ");
            nombre = Console.ReadLine();

            Console.WriteLine("Contraseña: ");
            contrasena = Console.ReadLine();

            // Aquí puedes implementar la lógica para validar las credenciales con los usuarios cargados.
            // Por ejemplo, podrías buscar el usuario en la lista de usuarios y comparar la contraseña.

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contrasena == contrasena)
                {
                    esValido = true;
                }
                else
                {
                    Usuario u = new Usuario();

                    Console.WriteLine("No estás registrado ! - Deseas registrarte (S/N) ? ");
                    string opcion = Console.ReadLine();

                    if (opcion == "S")
                    {
                        u = new Cliente(nombre, contrasena);
                        Console.WriteLine("Usuario registrado correctamente !");
                    }
                    else if (opcion == "N")
                    {
                        Console.WriteLine("No estás registrado");
                    }
                }
            }
            if (nombre == "admin" && contrasena == "1234")
            {
                esValido = true;
            }
            return esValido;
        }
    }
}
