using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ewig.Data
{
    public class AlbumData : EntityData<Album>
    {
        internal AlbumData()
        {
        }

        public Album GetByPK(int albumId)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Albums.FirstOrDefault(x => x.AlbumId == albumId);
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
    }
}
