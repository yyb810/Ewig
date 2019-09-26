using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class DataRepository
    {
        static DataRepository()
        {
            _album = new AlbumData();
        }

        private static AlbumData _album;

        public static AlbumData Album
        {
            get
            {
                return _album;
            }
        }
    }
}
