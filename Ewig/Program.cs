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
            List<Album> albums = DataRepository.Album.GetAll();

            Album album = DataRepository.Album.GetByPK(4);

            album.Title = DateTime.Now.ToString();
            DataRepository.Album.Update(album);

            int count = DataRepository.Album.GetCount();

            Album newAlbum = new Album();
            newAlbum.Title = DateTime.Now.ToString();
            DataRepository.Album.Insert(newAlbum);

            count = DataRepository.Album.GetCount();

            DataRepository.Album.Delete(newAlbum);

            count = DataRepository.Album.GetCount();
        }
    }
}
