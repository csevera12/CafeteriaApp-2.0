namespace CaferiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Empieza el programa cargando los usuarios en la lista para realizar las opciones del menú
            List<Usuario> usuarios = Usuario.CargarUsuarios("admins.txt");
        }
    }
}
