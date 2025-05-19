namespace CaferiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Visual visual= new Visual();
            visual.InicioPantalla();
            visual.NavegarOpciones();
            //Console.ReadKey();

            GestorApp ga = new GestorApp();
            //Empieza el programa cargando los usuarios en la lista para realizar las opciones del menú
            List<Usuario> usuarios = Usuario.CargarUsuarios("admins.txt");
            ga.IniciarApp();
        }
    }
}
