namespace CaferiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> usuarios = Usuario.CargarUsuarios("admins.txt");
            usuarios.AddRange(Usuario.CargarClientes("clientes.txt"));
            Visual visual = new Visual();

            // Guardamos la opción seleccionada: 0 = iniciar sesión, 1 = registro
            int opcionSeleccionada = visual.MostrarMenuInicio(usuarios);

            if (opcionSeleccionada == 0)
            {
                visual.VisualInicioSesion(usuarios);
            }

            else
            {
                 // Creamos la app con los datos correctos
                GestorApp ga = new GestorApp(usuarios, opcionSeleccionada);

                // Ahora sí iniciamos la app
                ga.IniciarApp();
            }
            

        }
    }
}
