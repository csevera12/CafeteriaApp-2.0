using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public abstract class Producto
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

        
        public static List<Producto> CargarProductos(string ruta)
        {
            List<Producto> productos = new List<Producto>();

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');

                    if (datos.Length == 5)
                    {
                        int codigo = int.Parse(datos[0]);
                        double precio = double.Parse(datos[1]);
                        string tipo = datos[2];
                        string nombre = datos[3];
                        int stock = int.Parse(datos[4]);

                        Producto producto = null;

                        if (tipo.ToLower() == "salado")
                        {
                            producto = new Salado(codigo, nombre, tipo, precio, stock);
                        }
                        else if (tipo.ToLower() == "dulce")
                        {
                            producto = new Dulce(codigo, nombre, tipo, precio, stock);
                        }
                        else if (tipo.ToLower() == "bebida")
                        {
                            producto = new Bebida(codigo, nombre, tipo, precio, stock);
                        }

                        if (producto != null)
                        {
                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }
        public static void GuardarProductos(string ruta, List<Producto> productos)
        {
            List<string> lineas = new List<string>();

            foreach (Producto p in productos)
            {
                string linea = $"{p.Codigo};{p.Nombre};{p.Tipo};{p.Precio};{p.Stock}";
                lineas.Add(linea);
            }

            File.WriteAllLines(ruta, lineas);
        }
        public override string ToString()
        {
            return $"{codigo}-{tipo}-{nombre}-{precio}-{stock}";
        }
    }
}
