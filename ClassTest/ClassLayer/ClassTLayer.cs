using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassTest.ClasssLayer;
using ClassTest.Models; 
using System.Data.Entity;
namespace ClassTest.ClassLayer
{
   public class ClassTLayer
    {
        public void Add(Class Class)
        {
            using (var db = new ClassContext())
            {
                db.Classs.Add(Class);
                db.SaveChanges();
            }
        }
        public List<Class> Query()
        {
            using (var db = new ClassContext())
            {
                return db.Classs.ToList();
            }
        }
        public Class Query(int id)
        {
            using (var db = new ClassContext())
            {
                return db.Classs.Find(id);
            }
        }
        public void Update(Class Class)
        {
            using (var db = new ClassContext())
            {
                db.Entry(Class).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(Class Class)
        {
            using (var db = new ClassContext())
            {
                db.Entry(Class).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
