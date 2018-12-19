using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Sex { get; set; }
        //相当于
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
