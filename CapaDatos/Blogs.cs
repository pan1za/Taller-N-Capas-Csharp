using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Blogs
    {
        public int blogID { get; set; }
        public string nombreBlog { get; set; }
        public int codigoUsuario { get; set; }
        public Blogs(int blogID, string nombreBlog, int codigoUsuario)
        {
            this.blogID = blogID;
            this.nombreBlog = nombreBlog;
            this.codigoUsuario = codigoUsuario;
        }
        public Blogs()
        {

        }
    }
}
