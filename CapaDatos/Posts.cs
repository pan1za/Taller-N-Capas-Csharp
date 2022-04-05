using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Posts
    {
        public int PostID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PostContent { get; set; }
        public string Title { get; set; }
        public int BlogBlogID { get; set; }
        public Posts(int PostID, DateTime CreatedDate, DateTime? ModifiedDate, string PostContent, 
            string Title, int BlogBlogID)
        {
            this.PostID = PostID;
            this.CreatedDate = CreatedDate;
            this.ModifiedDate = ModifiedDate;
            this.PostContent = PostContent;
            this.Title = Title;
            this.BlogBlogID = BlogBlogID;
        }
        public Posts()
        {

        }
    }
}
