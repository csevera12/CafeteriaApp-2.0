using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    public class Reserva
    {
        private string nombre;
        private int tlf;
        private int numComensales;
        private DateTime fecha;
        private TimeOnly hora;

        public Reserva(string nombre, int tlf, int numComensales, DateTime fecha, TimeOnly hora)
        {
            this.nombre = nombre;
            this.tlf = tlf;
            this.numComensales = numComensales;
            this.fecha = fecha;
            this.hora = hora;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Tlf { get => tlf; set => tlf = value; }
        public int NumComensales { get => numComensales; set => numComensales = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public TimeOnly Hora { get => hora; set => hora = value; }
    }
}
