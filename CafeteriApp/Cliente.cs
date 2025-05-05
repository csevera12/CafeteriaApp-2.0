using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    internal class Cliente : Usuario
    {
        public Cliente(string permisos,string username, string contrasena, long telefono)
         : base(permisos,username, contrasena,telefono)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
