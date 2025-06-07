using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class GestorApp
    {
        private List<Usuario> usuarios;
        private InicioSesion inicioSesion;
        private Cliente cliente;
        private Administrador admin;

        private static List<Reserva> reservas = new List<Reserva>();
        private static List<Producto> productos;
        private int opcionSeleccionada = 0; // 0 para iniciar sesión, 1 para registro


        public GestorApp(List<Usuario> usuarios, int opcionSeleccionada)
        {
            this.usuarios = usuarios;
            this.opcionSeleccionada = opcionSeleccionada;
            inicioSesion = new InicioSesion(this.usuarios);
        }

        public GestorApp()
        {

        }
        public GestorApp(Usuario usuario)
        {
            if (usuario is Cliente)
            {
                usuario = (Cliente)usuario;
            }
            else if (usuario is Administrador)
            {
                usuario = (Administrador)usuario;
            }
        }
        public void IniciarApp()
        {
            Usuario usuario = null;

            if (opcionSeleccionada == 0) // Iniciar sesión
            {
                usuario = inicioSesion.ValidarCredenciales();
            }
            else if (opcionSeleccionada == 1) // Registro
            {
                if (inicioSesion.RegistrarUsuario())
                {
                    Console.WriteLine("Registro exitoso. Por favor, inicie sesión.");
                    usuario = inicioSesion.ValidarCredenciales();
                }
                else
                {
                    Console.WriteLine("Error al registrar el usuario. Inténtelo de nuevo.");
                }
            }
        }
        public static string CentrarTexto(string texto, int anchoPantalla)
        {
            int espacios = (anchoPantalla - texto.Length) / 2;

            return espacios > 0 ? new string(' ', espacios) + texto : texto;
        }
        public static void OptCliente(Usuario usuario)
        {
            int anchoPantalla = Console.WindowWidth - 2;
            string opcion = "";
            while (opcion != "S")
            {
                opcion = GestorApp.MenuCliente();
                switch (opcion)
                {
                    case "1":
                        HacerPedido(usuario);
                        break;
                    case "2":
                        ReservarMesa(usuario);
                        break;
                    case "S":
                        Console.WriteLine(CentrarTexto("Saliendo de la aplicación...", anchoPantalla));
                        break;
                    default:
                        Console.WriteLine(CentrarTexto("Opción no válida. Inténtalo de nuevo.", anchoPantalla));
                        break;
                }
                Console.WriteLine();
            }
        }
        public static void OptAdmin()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            string opcion = "";
            while (opcion != "S")
            {
                opcion = GestorApp.MenuAdmin();
                switch (opcion)
                {
                    case "1":
                        CrearProducto();
                        break;
                    case "2":
                        EliminarProducto();
                        break;
                    case "3":
                        VerPedidosYCobrar();
                        break;
                    case "4":
                        AnyadirStock();
                        break;
                    case "5":
                        ModificarProducto();
                        break;
                    case "6":
                        VerProductos();
                        break;
                    case "7":
                        GestionarReservas();
                        break;
                    case "S":
                        Console.WriteLine(CentrarTexto("Saliendo de la aplicación...", anchoPantalla));
                        break;
                    default:
                        Console.WriteLine(CentrarTexto("Opción no válida. Inténtalo de nuevo.", anchoPantalla));
                        break;
                }
                Console.WriteLine();
            }
        }
        public static string MenuAdmin()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            Console.WriteLine(CentrarTexto("MENÚ ADMIN", anchoPantalla));
            Console.WriteLine(CentrarTexto("1.-Crear producto", anchoPantalla));
            Console.WriteLine(CentrarTexto("2.-Eliminar producto", anchoPantalla));
            Console.WriteLine(CentrarTexto("3.-Ver pedidos y cobrarlos", anchoPantalla));
            Console.WriteLine(CentrarTexto("4.-Añadir productos al stock", anchoPantalla));
            Console.WriteLine(CentrarTexto("5.-Modificar producto", anchoPantalla));
            Console.WriteLine(CentrarTexto("6.-Ver productos", anchoPantalla));
            Console.WriteLine(CentrarTexto("7.-Gestionar reservas", anchoPantalla));
            Console.WriteLine(CentrarTexto("S.-Salir", anchoPantalla));
            Console.Write(CentrarTexto("Elige una opción:", anchoPantalla));
            string opcion = Console.ReadLine();

            return opcion;
        }
        public static string MenuCliente()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            Console.WriteLine(CentrarTexto("MENÚ CLIENTE", anchoPantalla));
            Console.WriteLine(CentrarTexto("1.-Hacer pedido", anchoPantalla));
            Console.WriteLine(CentrarTexto("2.-Reservar mesa", anchoPantalla));
            Console.WriteLine(CentrarTexto("S.-Salir", anchoPantalla));
            Console.Write(CentrarTexto("Elige una opción:", anchoPantalla));
            string opcion = Console.ReadLine();


            return opcion;
        }

        public static void CrearProducto()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            productos = Producto.CargarProductos("productos.txt");
            Console.Write(CentrarTexto("Código: ", anchoPantalla));
            int codigo = int.Parse(Console.ReadLine());
            bool valido = false;
            // Verificar si el código ya existe
            while (!valido)
            {
                if (!productos.Any(p => p.Codigo == codigo))
                {
                    valido = true;
                }
                else
                {
                    Console.WriteLine(CentrarTexto("El código ya existe. Por favor, elige otro.", anchoPantalla));
                    Console.Write(CentrarTexto("Código: ", anchoPantalla));
                    codigo = int.Parse(Console.ReadLine());
                }
            }

            Console.Write(CentrarTexto("Nombre: ", anchoPantalla));
            string nombre = Console.ReadLine();

            Console.Write(CentrarTexto("Tipo (salado, dulce, bebida): ", anchoPantalla));
            string tipo = Console.ReadLine().ToLower();

            Console.Write(CentrarTexto("Precio: ", anchoPantalla));
            double precio = double.Parse(Console.ReadLine());

            Console.Write(CentrarTexto("Stock: ", anchoPantalla));
            int stock = int.Parse(Console.ReadLine());

            Producto nuevo = null;

            if (tipo == "salado")
            {
                nuevo = new Salado(codigo, nombre, tipo, precio, stock);
            }
            else if (tipo == "dulce")
            {
                nuevo = new Dulce(codigo, nombre, tipo, precio, stock);
            }
            else if (tipo == "bebida")
            {
                nuevo = new Bebida(codigo, nombre, tipo, precio, stock);
            }

            if (nuevo != null)
            {
                productos.Add(nuevo);
                Console.WriteLine(CentrarTexto("Producto creado correctamente.", anchoPantalla));
                Producto.GuardarProductos("productos.txt", productos);
            }
            else
            {
                Console.WriteLine(CentrarTexto("Tipo de producto no válido.", anchoPantalla));
            }
        }
        public static void EliminarProducto()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            productos = Producto.CargarProductos("productos.txt");

            Console.WriteLine();
            foreach (Producto producto in productos)
            {
                Console.WriteLine(CentrarTexto(producto.ToString(), anchoPantalla));
            }
            Console.WriteLine();

            Console.Write(CentrarTexto("Introduce el código del producto a eliminar: ", anchoPantalla));
            int codigo = int.Parse(Console.ReadLine());

            Producto productoAEliminar = productos.Find(p => p.Codigo == codigo);

            if (productoAEliminar != null)
            {
                productos.Remove(productoAEliminar);
                Console.WriteLine(CentrarTexto("Producto eliminado correctamente.", anchoPantalla));
            }
            else
            {
                Console.WriteLine(CentrarTexto("Producto no encontrado.", anchoPantalla));
            }
            Producto.GuardarProductos("productos.txt", productos);
        }
        public static void VerPedidosYCobrar()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            string rutaTxt = "pedidos.txt";

            List<string> pedidos = File.ReadAllLines(rutaTxt).ToList();

            if (pedidos.Count == 0)
            {
                Console.WriteLine(CentrarTexto("En estos momentos no hay pedidos", anchoPantalla));
            }

            Console.WriteLine(CentrarTexto("PEDIDOS: ", anchoPantalla));

            for (int i = 0; i < pedidos.Count; i++)
            {
                Console.WriteLine(CentrarTexto($"{i + 1}- {pedidos[i]}.", anchoPantalla));
            }

            Console.WriteLine();
            Console.Write(CentrarTexto("Introduce el número de pedido a cobrar: ", anchoPantalla));
            int opcion = int.Parse(Console.ReadLine());

            if (opcion > 0 && opcion <= pedidos.Count)
            {
                string pedido = pedidos[opcion - 1];
                pedidos.RemoveAt(opcion - 1);

                File.WriteAllLines(rutaTxt, pedidos);

                string[] datosFactura = pedido.Split(';');

                Console.WriteLine(CentrarTexto($"\nPedido entregado al cliente, el recibo es:\n" +
                          $"ID del pedido: {datosFactura[0]}\n" +
                          //$"Tipo: {datosFactura[2]}\n" +
                          $"Descripción: {datosFactura[3]}\n" +
                          $"Precio total: {datosFactura[1]}€\n" +
                          $"Estado: PAGADO", anchoPantalla));
            }
        }
        public static void AnyadirStock()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            productos = Producto.CargarProductos("productos.txt");

            Console.WriteLine();
            foreach (Producto producto in productos)
            {
                Console.WriteLine(CentrarTexto(producto.ToString(), anchoPantalla));
            }
            Console.WriteLine();

            Console.Write(CentrarTexto("Introduce el código del producto al que quieres añadir stock: ", anchoPantalla));
            int codigo = int.Parse(Console.ReadLine());
            Producto productoAActualizar = productos.Find(p => p.Codigo == codigo);
            if (productoAActualizar != null)
            {
                Console.Write(CentrarTexto("Introduce la cantidad de stock a añadir: ", anchoPantalla));
                int cantidad = int.Parse(Console.ReadLine());
                productoAActualizar.Stock += cantidad;
                Console.WriteLine(CentrarTexto("Stock actualizado correctamente.", anchoPantalla));
            }
            else
            {
                Console.WriteLine(CentrarTexto("Producto no encontrado.", anchoPantalla));
            }

            Producto.GuardarProductos("productos.txt", productos);
        }
        public static void ModificarProducto()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            productos = Producto.CargarProductos("productos.txt");
            Console.WriteLine();
            foreach (Producto producto in productos)
            {
                Console.WriteLine(CentrarTexto(producto.ToString(), anchoPantalla));
            }
            Console.WriteLine();

            Console.Write(CentrarTexto("Introduce el código del producto a modificar: ", anchoPantalla));
            int codigo = int.Parse(Console.ReadLine());
            Producto productoAModificar = productos.Find(p => p.Codigo == codigo);
            if (productoAModificar != null)
            {
                Console.Write(CentrarTexto("Nuevo nombre: ", anchoPantalla));
                productoAModificar.Nombre = Console.ReadLine();
                Console.Write(CentrarTexto("Nuevo tipo (salado, dulce, bebida): ", anchoPantalla));
                productoAModificar.Tipo = Console.ReadLine().ToLower();
                Console.Write(CentrarTexto("Nuevo precio: ", anchoPantalla));
                productoAModificar.Precio = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine(CentrarTexto("Producto no encontrado.", anchoPantalla));
            }
            Producto.GuardarProductos("productos.txt", productos);
        }
        public static void VerProductos()
        {
            int anchoPantalla = Console.WindowWidth - 2;

            productos = Producto.CargarProductos("productos.txt");
            Console.WriteLine();
            Console.WriteLine(CentrarTexto("Productos disponibles:", anchoPantalla));
            Console.WriteLine(CentrarTexto("Código\tNombre\tTipo\tPrecio\tStock", anchoPantalla));
            foreach (Producto producto in productos)
            {
                Console.WriteLine(CentrarTexto(producto.ToString(), anchoPantalla));
            }

        }
        public static void HacerPedido(Usuario usuario)
        {
            productos = Producto.CargarProductos("productos.txt");
            List<Comanda> pedidos = new List<Comanda>();
            List<Producto> productosPedidos = new List<Producto>();
            double precioTotal = 0;
            int anchoPantalla = Console.WindowWidth - 2;
            bool seguirPidiendo = true;
            int mesa = 0;

            int codigo = Comanda.VerCodigo("pedidos.txt");


            Console.WriteLine(CentrarTexto("Productos disponibles:", anchoPantalla));
            Console.WriteLine(CentrarTexto("Código\tNombre\tTipo\tPrecio", anchoPantalla));
            foreach (Producto producto in productos)
            {
                Console.WriteLine(CentrarTexto($"{producto.Codigo}-{producto.Nombre}-{producto.Tipo}-{producto.Precio}", anchoPantalla));
            }
            Console.WriteLine();

            while (seguirPidiendo)
            {
                Console.Write(CentrarTexto("Introduce el código del producto que quieres pedir: ", anchoPantalla));
                codigo = int.Parse(Console.ReadLine());
                Producto productoSeleccionado = productos.Find(p => p.Codigo == codigo);

                if (productoSeleccionado != null)
                {
                    Console.Write(CentrarTexto($"En qué mesa estás sentado?", anchoPantalla));
                    mesa = int.Parse(Console.ReadLine());
                    Console.Write(CentrarTexto("Introduce la cantidad que quieres pedir: ", anchoPantalla));
                    int cantidad = int.Parse(Console.ReadLine());
                    if (cantidad <= productoSeleccionado.Stock)
                    {
                        precioTotal += productoSeleccionado.Precio * cantidad;
                        productoSeleccionado.Stock -= cantidad;
                        Console.WriteLine(CentrarTexto($"Pedido realizado: {cantidad} {productoSeleccionado.Nombre}(s).", anchoPantalla));
                        Producto.GuardarProductos("productos.txt", productos);
                        productosPedidos.Add(productoSeleccionado);
                    }
                    else
                    {
                        Console.WriteLine(CentrarTexto("No hay suficiente stock disponible.", anchoPantalla));
                    }
                }
                else
                {
                    Console.WriteLine(CentrarTexto("Producto no encontrado.", anchoPantalla));
                }

                Console.Write(CentrarTexto("¿Quieres añadir otro producto? (S/N): ", anchoPantalla));

                if (Console.ReadLine().ToUpper() != "S")
                {
                    seguirPidiendo = false;
                }
            }

            //pedidos.Add(productosPedidos,mesa,codigo,usuario.Telefono);
        }
        public static void ReservarMesa(Usuario usuario)
        {
            int anchoPantalla = Console.WindowWidth - 2;

            Console.WriteLine(CentrarTexto("RESERVA DE MESA", anchoPantalla));

            string fechaTexto = "";
            DateTime fechaReserva = DateTime.MinValue;
            bool fechaValida = false;
            while (!fechaValida)
            {
                Console.Write(CentrarTexto("Introduce la fecha de la reserva (ejemplo: 05/06/2025): ", anchoPantalla));
                fechaTexto = Console.ReadLine();
                fechaValida = DateTime.TryParseExact(
                    fechaTexto,
                    "dd/MM/yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out fechaReserva
                );
                if (!fechaValida)
                {
                    Console.WriteLine(CentrarTexto("Formato de fecha incorrecto. Usa dd/MM/aaaa", anchoPantalla));
                }
            }

            string horaTexto = "";
            TimeOnly horaReserva = TimeOnly.MinValue;
            bool horaValida = false;
            while (!horaValida)
            {
                Console.Write(CentrarTexto("Introduce la hora de la reserva (ejemplo: 19:00): ", anchoPantalla));
                horaTexto = Console.ReadLine();
                horaValida = TimeOnly.TryParse(horaTexto, out horaReserva);
                if (!horaValida)
                {
                    Console.WriteLine(CentrarTexto("Formato de hora incorrecto. Usa HH:mm", anchoPantalla));
                }
            }

            string nombre = "";
            do
            {
                Console.Write(CentrarTexto("Introduce tu nombre: ", anchoPantalla));
                nombre = Console.ReadLine();
                if (nombre == "")
                {
                    Console.WriteLine(CentrarTexto("El nombre no puede estar vacío.", anchoPantalla));
                }
            } while (nombre == "");

            string tlfTexto = "";
            int tlf = 0;
            bool tlfValido = false;
            do
            {
                Console.Write(CentrarTexto("Introduce tu teléfono: ", anchoPantalla));
                tlfTexto = Console.ReadLine();
                tlfValido = tlfTexto.Length == 9 &&
                            (tlfTexto.StartsWith("6") || tlfTexto.StartsWith("7") || tlfTexto.StartsWith("8")) &&
                            int.TryParse(tlfTexto, out tlf);
                if (!tlfValido)
                {
                    Console.WriteLine(CentrarTexto("El teléfono debe tener 9 dígitos, empezar por 6, 7 u 8 y ser numérico.", anchoPantalla));
                }
            } while (!tlfValido);

            string comensalesTexto = "";
            int numComensales = 0;
            bool comensalesValidos = false;
            do
            {
                Console.Write(CentrarTexto("¿Cuántos comensales? ", anchoPantalla));
                comensalesTexto = Console.ReadLine();
                comensalesValidos = int.TryParse(comensalesTexto, out numComensales) && numComensales > 0;
                if (!comensalesValidos)
                {
                    Console.WriteLine(CentrarTexto("Introduce un número válido de comensales (mayor que 0).", anchoPantalla));
                }
            } while (!comensalesValidos);

            Reserva nuevaReserva = new Reserva(nombre, tlf, numComensales, fechaReserva, horaReserva);
            reservas.Add(nuevaReserva);

            string reservaTxt = $"{nombre};{tlf};{numComensales};{fechaReserva:dd/MM/yyyy};{horaReserva:HH\\:mm}";
            File.AppendAllText("reservas.txt", reservaTxt + Environment.NewLine);

            Console.WriteLine(CentrarTexto("¡Reserva realizada con éxito!", anchoPantalla));
        }
        public static void GestionarReservas()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            string opcion = "";
            do
            {
                Console.WriteLine(CentrarTexto("GESTIÓN DE RESERVAS", anchoPantalla));
                Console.WriteLine(CentrarTexto("1.-Ver reservas", anchoPantalla));
                Console.WriteLine(CentrarTexto("2.-Modificar reserva", anchoPantalla));
                Console.WriteLine(CentrarTexto("3.-Eliminar reserva", anchoPantalla));
                Console.WriteLine(CentrarTexto("S.-Salir", anchoPantalla));
                Console.Write(CentrarTexto("Elige una opción:", anchoPantalla));
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerReservas();
                        break;
                    case "2":
                        ModificarReserva();
                        break;
                    case "3":
                        EliminarReserva();
                        break;
                    case "S":
                        Console.WriteLine(CentrarTexto("Saliendo de gestión de reservas...", anchoPantalla));
                        break;
                    default:
                        Console.WriteLine(CentrarTexto("Opción no válida. Inténtalo de nuevo.", anchoPantalla));
                        break;
                }
                Console.WriteLine();
            } while (opcion != "S");
        }
        public static void VerReservas()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            if (reservas.Count == 0)
            {
                Console.WriteLine(CentrarTexto("No hay reservas registradas.", anchoPantalla));
            }
            else
            {
                Console.WriteLine(CentrarTexto("LISTA DE RESERVAS:", anchoPantalla));
                for (int i = 0; i < reservas.Count; i++)
                {
                    Reserva r = reservas[i];
                    Console.WriteLine(CentrarTexto($"{i + 1}. {r.Nombre} - {r.Tlf} - {r.NumComensales} comensales - {r.Fecha:dd/MM/yyyy} {r.Hora}", anchoPantalla));
                }
            }
        }

        public static void ModificarReserva()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            VerReservas();
            if (reservas.Count != 0)
            {
                Console.Write(CentrarTexto("Introduce el número de reserva a modificar: ", anchoPantalla));
                string input = Console.ReadLine();
                int idx = 0;
                bool idxValido = int.TryParse(input, out idx) && idx > 0 && idx <= reservas.Count;
                if (idxValido)
                {
                    Reserva reserva = reservas[idx - 1];
                    Console.Write(CentrarTexto("Nuevo nombre (deja vacío para no cambiar): ", anchoPantalla));
                    string nuevoNombre = Console.ReadLine();
                    if (nuevoNombre != "")
                        reserva.Nombre = nuevoNombre;

                    Console.Write(CentrarTexto("Nuevo teléfono (deja vacío para no cambiar): ", anchoPantalla));
                    string nuevoTlf = Console.ReadLine();
                    if (nuevoTlf != "" && nuevoTlf.Length == 9 &&
                        (nuevoTlf.StartsWith("6") || nuevoTlf.StartsWith("7") || nuevoTlf.StartsWith("8")) &&
                        int.TryParse(nuevoTlf, out int tlf))
                    {
                        reserva.Tlf = tlf;
                    }

                    Console.Write(CentrarTexto("Nuevo número de comensales (deja vacío para no cambiar): ", anchoPantalla));
                    string nuevoComensales = Console.ReadLine();
                    if (nuevoComensales != "" && int.TryParse(nuevoComensales, out int comensales) && comensales > 0)
                    {
                        reserva.NumComensales = comensales;
                    }

                    Console.Write(CentrarTexto("Nueva fecha (dd/MM/yyyy, deja vacío para no cambiar): ", anchoPantalla));
                    string nuevaFecha = Console.ReadLine();
                    DateTime fecha;
                    if (nuevaFecha != "" && DateTime.TryParseExact(nuevaFecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
                    {
                        reserva.Fecha = fecha;
                    }

                    Console.Write(CentrarTexto("Nueva hora (HH:mm, deja vacío para no cambiar): ", anchoPantalla));
                    string nuevaHora = Console.ReadLine();
                    TimeOnly hora;
                    if (nuevaHora != "" && TimeOnly.TryParse(nuevaHora, out hora))
                    {
                        reserva.Hora = hora;
                    }

                    Console.WriteLine(CentrarTexto("Reserva modificada correctamente.", anchoPantalla));
                }
                else
                {
                    Console.WriteLine(CentrarTexto("Selección no válida.", anchoPantalla));
                }
            }
        }

        public static void EliminarReserva()
        {
            int anchoPantalla = Console.WindowWidth - 2;
            VerReservas();
            if (reservas.Count != 0)
            {
                Console.Write(CentrarTexto("Introduce el número de reserva a eliminar: ", anchoPantalla));
                string input = Console.ReadLine();
                int idx = 0;
                bool idxValido = int.TryParse(input, out idx) && idx > 0 && idx <= reservas.Count;
                if (idxValido)
                {
                    reservas.RemoveAt(idx - 1);
                    Console.WriteLine(CentrarTexto("Reserva eliminada correctamente.", anchoPantalla));
                }
                else
                {
                    Console.WriteLine(CentrarTexto("Selección no válida.", anchoPantalla));
                }
            }
        }
    }
}