namespace CaferiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorApp ga = new GestorApp();
            Visual visual = new Visual();

            List<Usuario> usuarios = Usuario.CargarUsuarios("admins.txt");
            usuarios.AddRange(Usuario.CargarClientes("clientes.txt"));
            
            // Guardamos la opción seleccionada: 0 = iniciar sesión, 1 = registro
            int opcionSeleccionada = visual.MostrarMenuInicio(usuarios);

            if (opcionSeleccionada == 0)
            {
                visual.VisualInicioSesion(usuarios);
            }

            else
            {
                // Creamos la app con los datos correctos
                ga = new GestorApp(usuarios, opcionSeleccionada);

                // Ahora sí iniciamos la app
                ga.IniciarApp();
            }            
        }
    }
}
