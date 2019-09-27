using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ewig.Data
{
    public class AlbumData : EntityData<Album>
    {
        public Album GetByPK(int albumId)
        {
            return GetByPKCore(x => x.AlbumId == albumId);
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

        public override void Update(Album entity)
        {
            entity.Title = "!!!";

            base.Update(entity);
        }
    }
}
