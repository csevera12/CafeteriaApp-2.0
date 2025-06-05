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

        public static List<Comanda> CargarComandas()
        {
            List<Comanda> comandas = new List<Comanda>();
            string ruta = "pedidos.txt";
            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    if (datos.Length >= 4)
                    {
                        int codigo = int.Parse(datos[0]);
                        int mesa = int.Parse(datos[1]);
                        int tlf = int.Parse(datos[2]);
                        List<Producto> productos = new List<Producto>();

                        // Cargar todos los productos disponibles (ajusta la ruta según tu proyecto)
                        List<Producto> productosDisponibles = Producto.CargarProductos("productos.txt");

                        for (int i = 3; i < datos.Length; i++)
                        {
                            // Formato esperado: "Producto1(Producto)-cantidad(int)"
                            string[] partes = datos[i].Split('-');
                            if (partes.Length == 2)
                            {
                                string nombreProducto = partes[0];
                                int cantidad = int.Parse(partes[1]);

                                // Buscar el producto por nombre (ajusta si usas código u otro identificador)
                                Producto? productoBase = productosDisponibles
                                    .FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));

                                if (productoBase != null)
                                {
                                    for (int j = 0; j < cantidad; j++)
                                    {
                                        // Clonar el producto o crear una nueva instancia según tu lógica
                                        productos.Add(productoBase); // O clona si es necesario
                                    }
                                }
                                // Si no se encuentra el producto, podrías registrar un error o ignorar
                            }
                        }
                        Comanda comanda = new Comanda(productos, mesa, codigo, tlf);
                        comandas.Add(comanda);
                    }
                }
            }
            return comandas;
        }
        public static int VerCodigo(string ruta)
        {
            List<Comanda> comandas = CargarComandas();
            int codigo = 1;
            foreach (Comanda comanda in comandas)
            {
                if (comanda.Codigo > codigo)
                {
                    codigo = comanda.Codigo;
                }
            }
            return codigo + 1;
        }
    }
}
