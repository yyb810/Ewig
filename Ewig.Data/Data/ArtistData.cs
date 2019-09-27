namespace Ewig.Data
{
    public class ArtistData : EntityData<Artist>
    {
        public Artist GetByPK(int artistId)
        {
            return GetByPKCore(x => x.ArtistId == artistId);
        }
    }
}
