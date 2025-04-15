using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class Usuario
    {
        string nombre;
        string contrasena;
        string permisos;
        int telefono;

        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Permisos { get; set; }
        public int Telefono { get; set; }

        public Usuario(string permisos,string username, string contrasena,int telefono)
        {
            Nombre = username;
            Contrasena = contrasena;
            Permisos = permisos;
            Telefono = telefono;
        }
        public Usuario() { }

        public override string ToString()
        {
            return $"{permisos}:{nombre}:{contrasena}:{telefono}";
        }

        public static List<Usuario> CargarUsuarios(string rutaFichero)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                foreach (string linea in File.ReadAllLines(rutaFichero))
                {
                    string[] datos = linea.Trim().Split(':');
                    if (datos.Length == 4)
                    {
                        string permisos = datos[0];
                        string username = datos[1];
                        string contrasena = datos[2];
                        int telefono = Convert.ToInt32(datos[3]);
                        usuarios.Add(new Usuario(permisos, username, contrasena,telefono));
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
                    string[] datos = linea.Trim().Split(':');

                    if (datos.Length == 4)
                    {
                        string permisos = datos[0];
                        string username = datos[1];
                        string contrasena = datos[2];
                        int telefono = Convert.ToInt32(datos[3]);
                        clientes.Add(new Cliente(permisos, username, contrasena,telefono));
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

        public static void GuardarUsuarios(string rutaFichero)
        {
           List<Usuario> usuarios = new List<Usuario>();

           try
           {
                List<string> lineas = new List<String>();

                foreach (Usuario usuario in usuarios)
                {
                    string linea = $"{usuario.permisos}:{usuario.nombre}:{usuario.contrasena}:{usuario.telefono}";
                    lineas.Add(linea);
                }

                File.WriteAllLines(rutaFichero, lineas);
            }

            catch(Exception e)
            {
                Console.WriteLine($"Error al escribir en el fichero: {e.Message}");
            }
        }

        public static void GuardarClientes(string rutaFichero)
        {
            List<Usuario> clientes = new List<Usuario>();

            try 
            {
                List<string> lineas = new List<String>();

                foreach(Usuario cliente in clientes)
                {
                    string linea = $"{cliente.permisos}:{cliente.nombre}:{cliente.contrasena}:{cliente.telefono}";
                    lineas.Add(linea);
                }

                File.WriteAllLines(rutaFichero, lineas);
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error al escribir en el fichero: {e.Message}");
            }
        }        
    }
}
