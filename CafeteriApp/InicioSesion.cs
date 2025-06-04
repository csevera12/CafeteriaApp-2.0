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

        public Usuario ValidarCredenciales()
        {
            bool encontrado = false;
            int intentos = 3;
            int anchoPantalla = Console.WindowWidth - 2;
            Usuario usuarioGA = null;

            while (intentos > 0 && !encontrado)
            {
                Console.Write(CentrarTexto("Usuario: ", anchoPantalla));
                string nombre = Console.ReadLine();

                Console.Write(CentrarTexto("Contraseña: ", anchoPantalla));
                string contrasena = Console.ReadLine();

                foreach (Usuario usuario in usuarios)
                {
                    if (nombre == usuario.Nombre && contrasena == usuario.Contrasena)
                    {
                        List<Usuario> clientes = Usuario.CargarClientes("clientes.txt");
                        usuarioGA = clientes.Find(u => u.Nombre == nombre);

                        if (usuarioGA == null)
                        {
                            List<Usuario> admins = Usuario.CargarUsuarios("admins.txt");
                            usuarioGA = admins.Find(u => u.Nombre == nombre);
                        }
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    intentos--;
                    Console.WriteLine($"Usuario o contraseña incorrectos. Quedan {intentos} intentos");
                }
            }

            return usuarioGA;
            /*if (modoRegistro) 
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
            */
        }

        public bool RegistrarUsuario()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            bool registrado = false;
            bool existe = false;

            while (!registrado)
            {
                Console.Write(CentrarTexto("Usuario: ", anchoPantalla));
                string nombre = Console.ReadLine();
                Console.Write(CentrarTexto("Introduce tu contraseña:", anchoPantalla));
                string contrasena = Console.ReadLine();
                Console.Write(CentrarTexto("Introduce tu teléfono:", anchoPantalla));
                long telefono = Convert.ToInt64(Console.ReadLine());

                existe = false;

                foreach (Usuario u in usuarios)
                {
                    if (u.Nombre == nombre)
                    {
                        existe = true;

                    }
                }
                if (existe)
                {
                    Console.WriteLine("El usuario ya existe. Por favor, elige otro nombre de usuario.");
                }
                else
                {
                    usuarios.Add(new Cliente("C", nombre, contrasena, telefono));
                    Console.WriteLine("Usuario registrado correctamente.");
                    GuardarClientes("clientes.txt");
                    registrado = true;
                }
            }
            return registrado;
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
                File.WriteAllLines(rutaArchivo, lineas);
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