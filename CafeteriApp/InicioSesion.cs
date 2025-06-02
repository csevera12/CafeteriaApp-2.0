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

        public Usuario ValidarCredenciales(bool modoRegistro = false)
        {
            int anchoPantalla = Console.WindowWidth - 2;

            Console.Write(CentrarTexto("Usuario: ", anchoPantalla));
            string nombre = Console.ReadLine();

            Console.Write(CentrarTexto("Contraseña: ",anchoPantalla));
            string contrasena = Console.ReadLine();

            foreach (Usuario usuario in usuarios)
            {
                if (nombre == usuario.Nombre && contrasena == usuario.Contrasena)
                {
                    Console.WriteLine("BIENVENIDO " + nombre + " !");
                    return usuario;
                }
            }
            if (modoRegistro)
            {
                bool registrado = RegistrarUsuario(nombre, contrasena);
                if (registrado)
                {
                    Usuario nuevo = usuarios.Find(u => u.Nombre == nombre && u.Contrasena == contrasena);
                    return nuevo;

                }
                else
                {
                    return null;
                }

            }
            else
            {
                Console.WriteLine("No estás registrado! - ¿Deseas registrarte (S/N)? ");
                string opcion = Console.ReadLine();

                if (opcion?.ToUpper() == "S")
                {
                    bool registrado = RegistrarUsuario(nombre, contrasena);

                    if (registrado)
                    {
                        Usuario nuevo = usuarios.Find(u => u.Nombre == nombre && u.Contrasena == contrasena);
                        return nuevo;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Saliendo de la aplicación...");
                    return null;
                }

            }
        }

        private bool RegistrarUsuario(string nombre, string contrasena)
        {
            bool existe = false;

            foreach (Usuario u in usuarios)
            {
                if (u.Nombre == nombre)
                {
                    existe = true;
                }
            }

            if (existe)
            {
                Console.WriteLine("El nombre de usuario ya está registrado. Intenta con otro.");
                return false;
            }

            Console.WriteLine("Introduce tu teléfono:");
            long telefono = Convert.ToInt64(Console.ReadLine());

            usuarios.Add(new Cliente("C", nombre, contrasena, telefono));
            Console.WriteLine("Usuario registrado correctamente.");
            GuardarClientes("clientes.txt");

            return true;
        }
        private void GuardarClientes(string rutaArchivo)
        {
            try
            {
                List<string> lineas = new List<string>();

                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.Permisos == "C") // Solo guardamos clientes
                    {
                        string linea = $"{usuario.Permisos}:{usuario.Nombre}:{usuario.Contrasena}:{usuario.Telefono}";
                        lineas.Add(linea);
                    }
                }

                System.IO.File.WriteAllLines(rutaArchivo, lineas);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar los clientes: {e.Message}");
            }
        }

         public string CentrarTexto(string texto, int anchoPantalla)
        {
            int espacios = (anchoPantalla - texto.Length) / 2;

            return espacios > 0 ? new string(' ', espacios) + texto : texto;
        }

    }
}


