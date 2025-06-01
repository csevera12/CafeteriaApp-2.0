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
        int opcionSeleccionada = 0; // 0 para iniciar sesión, 1 para registro


        public GestorApp(List<Usuario> usuarios, int opcionSeleccionada)
        {
            this.usuarios = usuarios;
            this.opcionSeleccionada = opcionSeleccionada;
            inicioSesion = new InicioSesion(this.usuarios);
        }


        public void IniciarApp()
{
    if (opcionSeleccionada == 0) // Iniciar sesión
    {
        if (inicioSesion.ValidarCredenciales())
        {
            Console.WriteLine("Bienvenido a la aplicación de cafetería.");
        }
    }
    else if (opcionSeleccionada == 1) // Registro
    {
        inicioSesion.ValidarCredenciales(true); 
        Console.WriteLine("Registro completado. Ya puedes iniciar sesión.");
    }
}

    }
}