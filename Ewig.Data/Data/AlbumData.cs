using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class AlbumData
    {
        internal AlbumData()
        {
        }

        public int GetCount()
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Albums.Count();
            } // context.Dispose(); 자동 실행
        }

        public Album GetByPK(int albumId)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            }
        }

        public List<Album> GetAll()
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Albums.ToList();
            }
        }

        public int GetLastAlbumId()
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                //return context.Albums
                //        .OrderByDescending(x => x.AlbumId)
                //        .Select(x => x.AlbumId)
                //        .First();

            var query = from x in context.Albums
                        orderby x.AlbumId descending
                        select x.AlbumId;

            return query.First();
            }
        }

        public void Insert(Album album)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Albums.Add(album);

                context.SaveChanges();
            }
        }

        public void Update(Album album)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(album).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(Album album)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(album).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
