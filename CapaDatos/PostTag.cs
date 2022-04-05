using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PostTag
    {
        public int Post_PostID { get; set; }
        public int Tags_TagID { get; set; }
        public PostTag (int Post_PostID, int Tags_TagID)
        {
            this.Post_PostID = Post_PostID;
            this.Tags_TagID = Tags_TagID;
        }
    }
}
