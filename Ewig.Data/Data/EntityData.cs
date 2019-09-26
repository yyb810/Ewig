using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class EntityData<T> where T:class
    {
        public int GetCount()
        {
            using (EwigEntities context = new EwigEntities())
            {
                return context.Set<T>().Count();
            } // context.Dispose(); 자동 실행
        }

        public List<T> GetAll()
        {
            using (EwigEntities context = new EwigEntities())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Insert(T entity)
        {
            using (EwigEntities context = new EwigEntities())
            {
                context.Set<T>().Add(entity);

                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (EwigEntities context = new EwigEntities())
            {
                context.Entry(entity).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (EwigEntities context = new EwigEntities())
            {
                context.Entry(entity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
