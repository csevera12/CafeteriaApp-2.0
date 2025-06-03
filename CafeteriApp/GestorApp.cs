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

        Cliente cliente;
        Administrador admin;

        List<Producto> productosDisponibles;
        int opcionSeleccionada = 0; // 0 para iniciar sesión, 1 para registro


        public GestorApp(List<Usuario> usuarios, int opcionSeleccionada)
        {
            this.usuarios = usuarios;
            this.opcionSeleccionada = opcionSeleccionada;
            inicioSesion = new InicioSesion(this.usuarios);
        }
        public GestorApp(Usuario usuario)
        {
            if (usuario is Cliente)
            {
                this.cliente = (Cliente)usuario;
            }
            else if(usuario is Administrador)
            {
                this.admin = (Administrador)usuario;
            }
        }


        public void IniciarApp()
        {
            Usuario usuario = null;

            if (opcionSeleccionada == 0) // Iniciar sesión
            {
                usuario = inicioSesion.ValidarCredenciales(); 
            }
            else if (opcionSeleccionada == 1) // Registro
            {
                usuario = inicioSesion.ValidarCredenciales(true);
            }

            if (usuario != null)
            {
                Console.WriteLine("Bienvenido a la aplicación de cafetería, " + usuario.Nombre);
            }
            else
            {
                Console.WriteLine("Error: no se pudo iniciar sesión o registrar.");
            }
        }
        public void MenuAdministrador()
        {

        }
        public void MenuCliente()
        {
            
        }

    }
}



