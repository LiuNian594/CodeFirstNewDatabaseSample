using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个新博客
            //createBlog();
            //显示所有博客
            //QueryBlog();
            //Update();
            //QueryBlog();
            //Delete();
            AddPost();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
            //Console.WriteLine(blogId);
            //显示指定博客的帖子列表
            DisplatPosts(blogId);
            //根据指定到博客信息创建新帖子 

            //显示指定博客的帖子列表
        }
        static int GetBlogId()
        {
            //提示用户输入博客ID
            //获取用户输入，并入变量id
            //返回id
            Console.WriteLine("请输入博客id");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
        static void DisplatPosts(int blogId)
        {
            Console.WriteLine(blogId + "帖子列表");
            List<Post> list = null;
            //根据博客id获取博客
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                //Console.WriteLine(blogs.Name);
                //根据博客导航属性，获取所有该博客的帖子
                list = blog.Posts.ToList();
            }
            //BlogBusinessLayer bbl = new BlogBusinessLayer();
            //Blog blog = bbl.Query(blogId);
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
            foreach(var item in list)
            {
                Console.WriteLine(item.Blog.BlogId + "--" +item.Title);
            }
        }
         
        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.WriteLine(item.BlogId + " "+item.Name);
            }
        }
        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个博客id:");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
