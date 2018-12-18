using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using CodeFirstNewDatabaseSample.Models;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BusinessLayer
{
   public class BlogBusinessLayer
    {
       public void Add(Blog blog)
        {
            using(var db=new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using(var db=new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }
        public Blog Query(int id)
        {
            using(var db=new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void Update(Blog blog)
        {
            using(var db=new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
