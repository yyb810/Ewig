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
            //List<Album> albums = Album_GetAll();

            //Album album = Album_GetByPK(4);

            //album.Title = DateTime.Now.ToString();
            //Album_Update(album);

            //int count = Album_GetCount();

            //Album newAlbum = new Album();
            //newAlbum.Title = DateTime.Now.ToString();
            //Album_Insert(newAlbum);

            //count = Album_GetCount();

            //Album_Delete(newAlbum);

            //count = Album_GetCount();
        }

        public static int Album_GetCount()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=175.193.171.89;Initial Catalog=Chinook;User ID=sa;Password=3512";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select count(*) from Album";

            connection.Open();

            //command.ExecuteScalar - 스칼라 값을 반환
            //command.ExecuteReader - 벡터를 반환
            //command.ExecuteNonQuery - insert / update / delete

            int count = (int)command.ExecuteScalar();

            connection.Close();

            return count;
        }

        public static List<Album> Album_GetAll()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=175.193.171.89;Initial Catalog=Chinook;User ID=sa;Password=3512";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Album";

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Album> albums = new List<Album>();

            while (reader.Read())
            {
                Album album = new Album();
                album.AlbumId = reader.GetInt32(0);
                album.Title = reader.GetString(1);
                album.ArtistId = reader.GetInt32(2);

                albums.Add(album);
            }

            reader.Close();

            connection.Close();

            return albums;
        }

        public static Album Album_GetByPK(int albumId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=175.193.171.89;Initial Catalog=Chinook;User ID=sa;Password=3512";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Album where AlbumId = @AlbumId";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@AlbumId";
            parameter.Value = albumId;

            command.Parameters.Add(parameter);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool exist = reader.Read();

            if (exist == false)
                return null;

            Album album = new Album();
            album.AlbumId = reader.GetInt32(0);
            album.Title = reader.GetString(1);
            album.ArtistId = reader.GetInt32(2);
            reader.Close();

            connection.Close();

            return album;
        }

        public static int Add(int v1, int v2)
        {
            return v1 + v2;
        }
    }
}
