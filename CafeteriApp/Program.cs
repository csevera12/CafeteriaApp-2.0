namespace CaferiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Visual visual = new Visual();
            visual.InicioPantalla();

            // Guardamos la opción seleccionada: 0 = iniciar sesión, 1 = registro
            int opcionSeleccionada = visual.NavegarOpciones();

            
            List<Usuario> usuarios = Usuario.CargarUsuarios("admins.txt");
            usuarios.AddRange(Usuario.CargarClientes("clientes.txt"));


            // Creamos la app con los datos correctos
            GestorApp ga = new GestorApp(usuarios, opcionSeleccionada);

            // Ahora sí iniciamos la app
            ga.IniciarApp();
        }
    }
}
