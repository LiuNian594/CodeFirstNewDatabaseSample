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
            QueryPostForTitle();
            //创建一个新博客
            //createBlog();
            //显示所有博客
            //QueryBlog();
            //Update();
            //QueryBlog();
            //Delete();
            //AddPost();
            //Console.WriteLine("按任意键退出");
            //Console.ReadKey();
            //QueryBlog();
            //QueryABlog();
            //Console.WriteLine("0:退出 1：显示指定博客帖子列表 2:删除指定博客 3：更新指定博客 4:新增博客 ");
            //Menu();
            Console.ReadKey();
            //PostMenu();
        }
        public Blog QueryABlog(string name)
        {
            using(var db=new BloggingContext())
            {
                var blogs = from b in db.Blogs
                            where b.Name == name
                            select b;
                return blogs.FirstOrDefault();
            }
        }
        static void QueryPostForTitle()
        {
            Console.WriteLine("sssss");
            string name = Console.ReadLine();
            PostBusinessLayer pbl = new BusinessLayer.PostBusinessLayer();
            var query =pbl.
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
            Console.WriteLine("请输入将要添加的帖子标题");
            string title = Console.ReadLine();
            Console.WriteLine("请输入将要添加的帖子内容");
            string content = Console.ReadLine();
            Post post = new Post();
            post.Title = title;
            post.Content = content;
            post.BlogId = blogId;
            PostBusinessLayer pbl = new PostBusinessLayer();
            pbl.Add(post);
            //显示指定博客的帖子列表
            DisplatPosts(blogId);
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

        //显示全部博客
        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }
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
    //static void PostMenu()
    //{
    //    int blogId = GetBlogId();
    //    DisplaytPosts(blogId);
    //    List<Post> list = null;
    //    using (var db = new BloggingContext())
    //    {
    //        Blog blog = db.Blogs.Find(blogId);
    //        //根据导航属性，获取所有该博客的帖子
    //        list = blog.Posts.ToList();
    //    }
    //    if (list.Count == 0)
    //    {
    //        Console.WriteLine("该用户没有帖子");
    //        Console.WriteLine("1：新增贴子 2：更新帖子 3：删除帖子 4:退出");
    //        int ID = Convert.ToInt32(Console.ReadLine());
    //        if (ID == 1)
    //        {
    //            Console.WriteLine("请输入要添加的帖子标题");
    //            string title = Console.ReadLine();
    //            Console.WriteLine("请输入要添加的帖子内容");
    //            string content = Console.ReadLine();
    //            Post post = new Models.Post();
    //            post.Title = title;
    //            post.Content = content;
    //            post.BlogId = blogId;
    //            PostBusinessLayer pbl = new PostBusinessLayer();
    //            pbl.Add(post);
    //            //显示指定博客的帖子列表
    //            Console.WriteLine("新增成功！！！");
    //            DisplaytPosts(blogId);
    //            PostMenu();
    //        }
    //        if (ID == 2)
    //        {
    //            UpdataPost();
    //            Console.WriteLine("更新成功！！！");
    //            DisplaytPosts(blogId);
    //            PostMenu();

    //        }
    //        if (ID == 3)
    //        {
    //            DeletePost();
    //            Console.WriteLine("删除成功！！！");
    //            DisplaytPosts(blogId);
    //            PostMenu();
    //        }
    //        if (ID == 4)
    //        {
    //            return;
    //        }

    //    }
    //    else
    //    {
    //        Console.WriteLine("1：新增贴子 2：更新帖子 3：删除帖子");
    //        int ID = Convert.ToInt32(Console.ReadLine());
    //        if (ID == 1)
    //        {
    //            Console.WriteLine("请输入要添加的帖子标题");
    //            string title = Console.ReadLine();
    //            Console.WriteLine("请输入要添加的帖子内容");
    //            string content = Console.ReadLine();
    //            Post post = new Models.Post();
    //            post.Title = title;
    //            post.Content = content;
    //            post.BlogId = blogId;
    //            PostBusinessLayer pbl = new PostBusinessLayer();
    //            pbl.Add(post);
    //            //显示指定博客的帖子列表
    //            Console.WriteLine("新增成功！！！");
    //            DisplaytPosts(blogId);
    //        }
    //        if (ID == 2)
    //        {
    //            UpdataPost();
    //            Console.WriteLine("更新成功！！！");
    //            DisplaytPosts(blogId);

    //        }
    //        if (ID == 3)
    //        {
    //            DeletePost();
    //            Console.WriteLine("删除成功！！！");
    //            DisplaytPosts(blogId);
    //        }

    //    }
    //}
}
