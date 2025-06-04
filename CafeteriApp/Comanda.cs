using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    internal class Comanda
    {
        private List<Producto> productos;
        private int mesa;
        private int codigo;
        private int tlf;

        public Comanda(List<Producto> productos, int mesa, int codigo, int tlf)
        {
            this.productos = productos;
            this.mesa = mesa;
            this.codigo = codigo;
            this.tlf = tlf;
        }

        public int Mesa { get => mesa; set => mesa = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public int Tlf { get => tlf; set => tlf = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
    }
}
