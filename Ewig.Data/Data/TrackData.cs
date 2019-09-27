using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class TrackData : EntityData<Track>
    {
        public Track GetByPK(int trackId)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Tracks.FirstOrDefault(x => x.TrackId == trackId);
            }
        }
    }
}
