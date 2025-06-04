using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    internal class Pedido
    {
        private string numero;
        private string mesa;
        private List<Producto> productos;

        public Pedido(string pedido)
        {
        }
        public Pedido()
        {

        }
        public Pedido(string numero, string mesa, string pedido)
        {
            this.Numero = numero;
            this.Mesa = mesa;
        }

        public string Numero { get => numero; set => numero = value; }
        public string Mesa { get => mesa; set => mesa = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }

        public override string ToString()
        {
            return numero + mesa ;
        }
    }
}
