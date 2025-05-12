using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CaferiApp
{
    public class Visual
    {
        public void InicioPantalla()
        {
            Console.Clear();    

            int anchoPantalla = 60;
            string borde = new string('-', anchoPantalla);
            string titulo = "CAFETERIA APP";
            string dibujoCafe = "   ( (   \n    ) )  \n  ........\n  |      |]\n  \\      /\n   `----'";
            string botonInicioSesion = "[ INICIO SESIÓN ]";
            string  botonRegistro = "[ REGISTRO ]";

            Console.WriteLine(borde);
            Console.WriteLine(CentrarTexto("", anchoPantalla));
            Console.WriteLine(CentrarTexto(titulo, anchoPantalla));
            Console.WriteLine();

            foreach (string linea in dibujoCafe.Split('\n'))
            {
                Console.WriteLine(CentrarTexto(linea, anchoPantalla));
            }
        }


        public string CentrarTexto(string texto, int anchoPantalla)
        {
            int espacios = (anchoPantalla - texto.Length) / 2;
            
            if (espacios == 0)
            {
                espacios = 0;
            }

            return new string (' ', espacios) + texto; 
        }
    }
}
