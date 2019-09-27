using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ewig.Data
{
    public class ArtistData
    {
        internal ArtistData()
        {
        }

        public int GetCount()
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Artists.Count();
            } // context.Dispose(); 자동 실행
        }

        public Artist GetByPK(int artistId)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Artists.FirstOrDefault(x => x.ArtistId == artistId);
            }
        }

        public List<Artist> GetAll()
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Artists.ToList();
            }
        }

        public void Insert(Artist artist)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Artists.Add(artist);

                context.SaveChanges();
            }
        }

        public void Update(Artist artist)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(artist).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(Artist artist)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(artist).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
