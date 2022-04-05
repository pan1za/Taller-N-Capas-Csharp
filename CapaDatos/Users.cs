using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Users
    {
        public string usuario { get; set; }
        public int codigo { get; set; }
        public Users(string usuario, int codigo)
        {
            this.usuario = usuario;
            this.codigo = codigo;
        }

       
    }
}