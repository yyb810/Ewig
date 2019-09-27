using Ewig.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Track> list = DataRepository.Track.Get(x => x.AlbumId == 100);

            foreach (var track in list)
            {
                Console.WriteLine($"{track.TrackId} / {track.AlbumId}");
            }
        }
    }
}
