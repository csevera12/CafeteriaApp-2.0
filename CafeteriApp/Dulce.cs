using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    internal class Dulce : Producto
    {
        public Dulce(int codigo, string nombre, string tipo, double precio, int stock)
            : base(codigo, nombre, tipo, precio, stock)
        {
            //hola
        }
    }
}
