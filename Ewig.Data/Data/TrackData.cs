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
            return GetByPKCore(x => x.TrackId == trackId);
        }
    }
}
