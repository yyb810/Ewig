using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class EntityData<T> where T:class
    {
        public int GetCount(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                predicate = (x) => true;

            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Set<T>().Count(predicate);
            }
        }

        public List<T> GetAll()
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Insert(T entity)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Set<T>().Add(entity);

                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(entity).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(entity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
