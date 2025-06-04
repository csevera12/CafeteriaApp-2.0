using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    abstract class Producto
    {
        protected int codigo;
        protected string nombre;
        protected string tipo;
        protected double precio;
        protected int stock;

        protected Producto(int codigo, string nombre, string tipo, double precio, int stock)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.tipo = tipo;
            this.precio = precio;
            this.stock = stock;
        }

        public Producto()
        {
            codigo = 0;
            precio = 0;
            nombre = " ";
            tipo = " ";
            stock = 0;
        }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }

        public override string ToString()
        {
            return nombre + tipo + precio;
        }
    }
}
