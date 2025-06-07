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
        protected string nombre;
        protected string contrasena;
        protected string permisos;
        protected long telefono;

        public string Permisos { get => permisos; set => permisos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public long Telefono { get => telefono; set => telefono = value; }

        public Usuario(string permisos,string username,
        string contrasena,long telefono)
        {
            Permisos = permisos;
            Nombre = username;
            Contrasena = contrasena;         
            Telefono = telefono;
        }
        public Usuario() { }

        public override string ToString()
        {
            return $"{Permisos}:{Nombre}:{Contrasena}:{Telefono}";
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
                        long telefono = Convert.ToInt64(datos[3]);
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
                        long telefono = Convert.ToInt64(datos[3]);
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
                    string linea = $"{usuario.Permisos}:{usuario.Nombre}:{usuario.Contrasena}:{usuario.Telefono}";
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
                    string linea = $"{cliente.Permisos}:{cliente.Nombre}:{cliente.Contrasena}:{cliente.Telefono}";
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
