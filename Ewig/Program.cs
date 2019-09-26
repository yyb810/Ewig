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

        public static void Album_Delete(Album album)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=175.193.171.89;Initial Catalog=Chinook;User ID=sa;Password=3512";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete Album where AlbumId = @AlbumId";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@AlbumId";
            parameter.Value = album.AlbumId;
            command.Parameters.Add(parameter);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public static int Album_GetLastAlbumId()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=175.193.171.89;Initial Catalog=Chinook;User ID=sa;Password=3512";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select top 1 AlbumId from Album order by AlbumId desc";

            connection.Open();

            int count = (int)command.ExecuteScalar();

            connection.Close();

            return count;
        }

        public static void Album_Insert(Album album)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=175.193.171.89;Initial Catalog=Chinook;User ID=sa;Password=3512";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "insert into Album values(@Title, @ArtistId)";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Title";
            parameter.Value = album.Title;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@ArtistId";
            parameter.Value = album.ArtistId;
            command.Parameters.Add(parameter);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
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

        public static void Album_Update(Album album)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=175.193.171.89;Initial Catalog=Chinook;User ID=sa;Password=3512";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "update Album set Title = @Title,  ArtistId = @ArtistId where AlbumId = @AlbumId";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@AlbumId";
            parameter.Value = album.AlbumId;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Title";
            parameter.Value = album.Title;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@ArtistId";
            parameter.Value = album.ArtistId;
            command.Parameters.Add(parameter);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
