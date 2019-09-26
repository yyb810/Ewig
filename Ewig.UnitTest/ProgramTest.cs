// TDD (Test-Driven-Development)
// Attribute
// Reflection


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ewig.Data;

namespace Ewig.UnitTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void Album_GetCountTest()
        {
            int count = DataRepository.Album.GetCount();
            
            Assert.AreEqual(347, count);
        }

        [TestMethod()]
        public void Album_GetByPKTest()
        {
            Album album = DataRepository.Album.GetByPK(1);
            
            Assert.AreEqual("For Those About To Rock We Salute You", album.Title);
            Assert.AreEqual(1, album.ArtistId);
        }

        [TestMethod()]
        public void Album_GetAllPKTest()
        {
            List<Album> albums = DataRepository.Album.GetAll();

            Assert.AreEqual(347, albums.Count);
            
            Assert.AreEqual("For Those About To Rock We Salute You", albums[0].Title);
            Assert.AreEqual(1, albums[0].ArtistId);
        }

        [TestMethod()]
        public void Album_InsertTest()
        {
            int oldCount = DataRepository.Album.GetCount();

            Album album = new Album();
            album.Title = DateTime.Now.ToString();
            album.ArtistId = 1;

            DataRepository.Album.Insert(album);

            int newCount = DataRepository.Album.GetCount();

            Assert.AreEqual(oldCount + 1, newCount);
        }

        [TestMethod()]
        public void Album_UpdateTest()
        {
            string now = DateTime.Now.ToString();

            Album album = DataRepository.Album.GetByPK(2);

            album.Title = now;
            DataRepository.Album.Update(album);

            album = DataRepository.Album.GetByPK(2);

            Assert.AreEqual(now, album.Title);
        }

        [TestMethod()]
        public void Album_DeleteTest()
        {
            int lastAlbumId = DataRepository.Album.GetLastAlbumId();
            Album album = DataRepository.Album.GetByPK(lastAlbumId);

            DataRepository.Album.Delete(album);

            album = DataRepository.Album.GetByPK(lastAlbumId);

            Assert.IsNull(album);
        }

        [TestMethod()]
        public void Album_GetLastTest()
        {
            int oldMaxAlbumId = DataRepository.Album.GetLastAlbumId();

            Album album = new Album();
            album.Title = DateTime.Now.ToString();
            album.ArtistId = 1;
            DataRepository.Album.Insert(album);

            int newMaxAlbumId = DataRepository.Album.GetLastAlbumId();

            Assert.AreEqual(oldMaxAlbumId + 1, newMaxAlbumId);
        }
    }
}
