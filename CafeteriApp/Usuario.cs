using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class Usuario
    {
        string nombre;
        string contrasena;
        //string permisos;

        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        //public string Permisos { get; set; }

        public Usuario(string username, string contrasena)
        {
            Nombre = username;
            Contrasena = contrasena;
        }
        public Usuario() { }

        public static List<Usuario> CargarUsuarios(string rutaFichero)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                foreach (string linea in File.ReadAllLines(rutaFichero))
                {
                    string[] datos = linea.Trim().Split(':');
                    if (datos.Length == 3)
                    {
                        string permisos = datos[0];
                        string username = datos[1];
                        string contrasena = datos[2];
                        usuarios.Add(new Usuario(username, contrasena));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El fichero {rutaFichero} no existe.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al leer el fichero: {e.Message}");
            }
            return usuarios;
        }

        public static List<Usuario> CargarClientes(string rutaFichero)
        {
            List<Usuario> clientes = new List<Usuario>();

            try
            {
                foreach (string linea in File.ReadAllLines(rutaFichero))
                {
                    string[] datos = linea.Split(':');

                    if (datos.Length == 3)
                    {
                        string permisos = datos[0];
                        string username = datos[1];
                        string contrasena = datos[2];
                        clientes.Add(new Usuario(username, contrasena));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El fichero {rutaFichero} no existe.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al leer el fichero: {e.Message}");
            }

            return clientes;
        }

        /////HOLA
    }
}
