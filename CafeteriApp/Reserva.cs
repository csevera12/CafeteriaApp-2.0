using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    internal class Reserva
    {
        private List<Cliente> comenasles;
        private string nombre;
        private int tlf;
        private int numComensales;
        private DateTime fecha;

        public Reserva(List<Cliente> comenasles, string nombre, int tlf, int numComensales, DateTime fecha)
        {
            this.comenasles = comenasles;
            this.nombre = nombre;
            this.tlf = tlf;
            this.numComensales = numComensales;
            this.fecha = fecha;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Tlf { get => tlf; set => tlf = value; }
        public int NumComensales { get => numComensales; set => numComensales = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        internal List<Cliente> Comenasles { get => comenasles; set => comenasles = value; }
    }
}
