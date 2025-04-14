using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    abstract class Producto
    {
        private int codigo;
        private string nombre;
        private string tipo;
        private double precio;
        private int stock;

        protected Producto(int codigo, string nombre, string tipo, double precio, int stock)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.tipo = tipo;
            this.precio = precio;
            this.stock = stock;
        }

        protected int Codigo { get => codigo; set => codigo = value; }
        protected string Nombre { get => nombre; set => nombre = value; }
        protected string Tipo { get => tipo; set => tipo = value; }
        protected double Precio { get => precio; set => precio = value; }
        protected int Stock { get => stock; set => stock = value; }
    }
}
