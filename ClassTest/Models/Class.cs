using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        //导航属性，目的是通过博客对象访问到一组帖子
        public virtual List<Student> Student { get; set; }
    }
}
