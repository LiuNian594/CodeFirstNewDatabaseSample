using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //相当于
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

    }
    //多方加入一方键和实体
}
