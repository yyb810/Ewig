using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class DataRepository
    {
        public static AlbumData Album {get;} = new AlbumData();
        public static ArtistData Artist {get;} = new ArtistData();
        public static TrackData Track {get;} = new TrackData();
    }
}
