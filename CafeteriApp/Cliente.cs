using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaferiApp
{
    internal class Cliente : Usuario
    {
        public Cliente(string username, string contrasena) : base(username, contrasena)
        {
        }
    }
}
