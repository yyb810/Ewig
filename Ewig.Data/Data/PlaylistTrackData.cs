using System.Linq;

namespace Ewig.Data
{
    public class PlaylistTrackData : EntityData<PlaylistTrack>
    {
        public PlaylistTrack GetByPK(int playlistId, int trackId)
        {
            return GetByPKCore(x => x.PlaylistId == playlistId && x.TrackId == trackId);
        }
    }
}
