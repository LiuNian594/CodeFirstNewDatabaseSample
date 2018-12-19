using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassTest.Models;
using System.Data.Entity;

namespace ClassTest.ClasssLayer
{
    public class ClassContext:DbContext
    {
        public DbSet<Class> Classs { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
