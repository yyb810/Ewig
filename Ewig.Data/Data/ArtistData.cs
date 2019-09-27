using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ewig.Data
{
    public class ArtistData : EntityData<Artist>
    {
        internal ArtistData()
        {
        }

        public Artist GetByPK(int artistId)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Artists.FirstOrDefault(x => x.ArtistId == artistId);
            }
        }
    }
}
