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
            string botonInicioSesion = "[ INICIO SESIÓN ]";
            string botonRegistro = "[ REGISTRO ]";
            int margen = (altoPantalla - 10) / 3;

            Console.WriteLine(borde);

            for (int i = 0; i < margen; i++)
            {
                Console.WriteLine(CentrarTexto("", anchoPantalla));
            }

            Console.WriteLine(CentrarTexto("", anchoPantalla));
            Console.WriteLine();

            foreach (string linea in dibujoCafe.Split('\n'))
            {
                Console.WriteLine(CentrarTexto(linea, anchoPantalla));
            }

            Console.WriteLine();
            Console.WriteLine(CentrarTexto(botonInicioSesion, anchoPantalla));
            Console.WriteLine(CentrarTexto(botonRegistro, anchoPantalla));

            for (int i = 0; i < margen - 2; i++)
            {
                Console.WriteLine(CentrarTexto("", anchoPantalla));
            }

            Console.WriteLine(borde);
        }

        public void ColorOpciones()
        {
            Console.ForegroundColor = opcionMenu == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(CentrarTexto("[INICIO SESIÓN]", Console.WindowWidth - 2));
            Console.ForegroundColor = opcionMenu == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(CentrarTexto("[REGISTRO]", Console.WindowWidth - 2));

            Console.ResetColor();
            
        }

        private void NavegarOpciones()
    {
        ConsoleKeyInfo tecla;
        do
        {
            tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.UpArrow || tecla.Key == ConsoleKey.DownArrow)
            {
                opcionMenu = opcionMenu == 0 ? 1 : 0;
                Console.Clear();
                InicioPantalla();
            }

        } while (tecla.Key != ConsoleKey.Enter);

        Console.Clear();
        //Console.WriteLine($"Has seleccionado: {(opcionMenu == 0 ? "Inicio Sesión" : "Registro")}");
    }

        public string CentrarTexto(string texto, int anchoPantalla)
        {
            int espacios = (anchoPantalla - texto.Length) / 2;

            if (espacios < 0)
            {
                espacios = 0;
            }

            return new string(' ', espacios) + texto;
        }
    }
}
