using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CaferiApp
{
    public class Visual
    {
        int opcionMenu = 0;
        public void InicioPantalla()
        {
            Console.Clear();

            int anchoPantalla = Console.WindowWidth - 2;
            int altoPantalla = Console.WindowHeight - 2;
            string borde = new string('-', anchoPantalla);
            string titulo = "CAFETERIA APP";
            string dibujoCafe = "   ( (   \n    ) )  \n  ........\n  |      |]\n  \\      /\n   `----'";
            int margen = (altoPantalla - 10) / 3;

            Console.WriteLine(borde);

            for (int i = 0; i < margen; i++)
            {
                Console.WriteLine(CentrarTexto("", anchoPantalla));
            }

            Console.WriteLine(CentrarTexto(titulo, anchoPantalla));
            Console.WriteLine();

            foreach (string linea in dibujoCafe.Split('\n'))
            {
                Console.WriteLine(CentrarTexto(linea, anchoPantalla));
            }

            Console.WriteLine();

            ColorOpciones();

            for (int i = 0; i < margen - 2; i++)
            {
                Console.WriteLine(CentrarTexto("", anchoPantalla));
            }

            Console.WriteLine(borde);
        }

        public void ColorOpciones()
        {
            Console.ForegroundColor = opcionMenu == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(CentrarTexto("[ INICIO SESIÓN ]", Console.WindowWidth - 2));
            Console.ForegroundColor = opcionMenu == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(CentrarTexto("[ REGISTRO ]", Console.WindowWidth - 2));

            Console.ResetColor();
        }

        public int NavegarOpciones()
        {
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.UpArrow || tecla.Key == ConsoleKey.DownArrow)
                {
                    opcionMenu = opcionMenu == 0 ? 1 : 0;

                    InicioPantalla();
                }

            } while (tecla.Key != ConsoleKey.Enter);

            return opcionMenu;
        }

        public int MostrarMenuInicio(List<Usuario> usuarios)
        {
            InicioPantalla();
            int seleccionarOpcion = NavegarOpciones();

            if (seleccionarOpcion == 1)
            {
                VisualRegistro();
            }

            else
             {
                VisualInicioSesion(usuarios);
             }

            return seleccionarOpcion;
        }

        public void VisualRegistro()
        {
            Console.Clear();

            int anchoPantalla = Console.WindowWidth - 2;
            int altoPantalla = Console.WindowHeight - 2;
            string borde = new string('-', anchoPantalla);
            int margen = (altoPantalla - 12) / 2;

            Console.WriteLine(borde);

            for (int i = 0; i < margen; i++)
            {
                Console.WriteLine(CentrarTexto("", anchoPantalla));
            }

            Console.WriteLine(CentrarTexto("VERIFICANDO DE NUEVO LAS CREDENCIALES", anchoPantalla));
            Console.WriteLine();

            Console.Write(CentrarTexto("Numero de teléfono: ", anchoPantalla));
            long tlf = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(CentrarTexto("Registro completado", anchoPantalla));

            Console.ReadKey();
        }

        public string CentrarTexto(string texto, int anchoPantalla)
        {
            int espacios = (anchoPantalla - texto.Length) / 2;

            return espacios > 0 ? new string(' ', espacios) + texto : texto;
        }

        public void VisualInicioSesion(List<Usuario> usuarios)
        {
            Console.Clear();

            int anchoPantalla = Console.WindowWidth - 2;
            int altoPantalla = Console.WindowHeight - 2;
            string borde = new string('-', anchoPantalla);
            int margen = (altoPantalla - 12) / 2;

            Console.WriteLine(borde);

            for (int i = 0; i < margen; i++)
            {
                Console.WriteLine(CentrarTexto("", anchoPantalla));
            }

            Console.WriteLine(CentrarTexto("POR FAVOR, INICIA SESIÓN", anchoPantalla));
            Console.WriteLine();

            InicioSesion inicioSesion = new InicioSesion(usuarios);
            Usuario usuario = inicioSesion.ValidarCredenciales();

            Console.Clear();

            if (usuario != null)
            {
                Console.WriteLine(CentrarTexto("Bienvenido " + usuario.Nombre + "!", anchoPantalla));
                //PARA HACER QUE FUNCIONE LA APP, SE DEBE CREAR UNA INSTANCIA DE GestorApp CON EL
                //USUARIO y a partir de ahi, crear las funciones
                GestorApp gestorApp = new GestorApp(usuario);
                if(usuario is Cliente cliente)
                {
                    gestorApp.MenuAdministrador();
                    //gestorApp.ClientePide();
                }
            }

            else
            {
                Console.WriteLine(CentrarTexto("Credenciales incorrectas. Registrate", anchoPantalla));
            }

            Console.ReadKey();
        }
        
    }
}
