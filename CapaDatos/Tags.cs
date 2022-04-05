using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Tags
    {
        public int TagID  { get; set; }
        public string Name { get; set; }
        public Tags(int TagID, string Name)
        {
            this.TagID = TagID;
            this.Name = Name;
        }
    }
}
