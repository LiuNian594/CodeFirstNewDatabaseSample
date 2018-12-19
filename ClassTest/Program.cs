using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassTest.Models;
using ClassTest.ClassLayer;
namespace ClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个新博客
            createBlog();
            //显示所有博客
            //QueryBlog();
            //Update();
            //QueryBlog();
            //Delete();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        static void createBlog()
        {
            Console.WriteLine("请输入一个班级");
            string classname = Console.ReadLine();
            Class Class = new Class();
            Class.ClassName = classname;
            ClassTLayer bbl = new ClassTLayer();
            bbl.Add(Class);
        }
        //显示全部博客
        static void QueryBlog()
        {
            ClassTLayer bbl = new ClassTLayer();
            var Classs = bbl.Query();
            foreach (var item in Classs)
            {
                Console.WriteLine(item.ClassId + " " + item.ClassName);

            }
        }
        static void Update()
        {
            Console.WriteLine("请输入班级id");
            int classid = int.Parse(Console.ReadLine());
            ClassTLayer bbl = new ClassTLayer();
            Class Class = bbl.Query(classid);
            Console.WriteLine("请输入新名字");
            string classname = Console.ReadLine();
            Class.ClassName = classname;
            bbl.Update(Class);
        }
        static void Delete()
        {
            ClassTLayer bbl = new ClassTLayer();
            Console.Write("请输入一个班级id:");
            int classid = int.Parse(Console.ReadLine());
            Class Class = bbl.Query(classid);
            bbl.Delete(Class);
        }
    }
}
