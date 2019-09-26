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
            AlbumData albumData = new AlbumData();

            List<Album> albums = albumData.GetAll();

            Album album = albumData.GetByPK(4);

            album.Title = DateTime.Now.ToString();
            albumData.Update(album);

            int count = albumData.GetCount();

            Album newAlbum = new Album();
            newAlbum.Title = DateTime.Now.ToString();
            albumData.Insert(newAlbum);

            count = albumData.GetCount();

            albumData.Delete(newAlbum);

            count = albumData.GetCount();
        }
    }
}
