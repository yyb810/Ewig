using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ewig.Data;

namespace Ewig.UnitTest
{
    [TestClass]
    public class ArtistDataTest
    {
        [TestMethod]
        public void Artist_GetCountTest()
        {
            int count = DataRepository.Artist.GetCount();
            
            Assert.IsTrue(count > 0);
        }

        [TestMethod()]
        public void Artist_GetByPKTest()
        {
            Artist artist = DataRepository.Artist.GetByPK(1);
            
            Assert.AreEqual("AC/DC", artist.Name);
            Assert.AreEqual(1, artist.ArtistId);
        }

        [TestMethod()]
        public void Artist_GetAllPKTest()
        {
            List<Artist> artists = DataRepository.Artist.GetAll();

            Assert.IsTrue(artists.Count > 0);
            
            Assert.AreEqual("Twice", artists[0].Name);
            Assert.AreEqual(0, artists[0].ArtistId);
        }

        [TestMethod()]
        public void Artist_InsertTest()
        {
            int oldCount = DataRepository.Artist.GetCount();

            Artist artist = new Artist();
            artist.Name = DateTime.Now.ToString();
            
            DataRepository.Artist.Insert(artist);

            int newCount = DataRepository.Artist.GetCount();

            Assert.AreEqual(oldCount + 1, newCount);
        }

        [TestMethod()]
        public void Artist_UpdateTest()
        {
            string now = DateTime.Now.ToString();

            Artist artist = DataRepository.Artist.GetByPK(2);

            artist.Name = now;
            DataRepository.Artist.Update(artist);

            artist = DataRepository.Artist.GetByPK(2);

            Assert.AreEqual(now, artist.Name);
        }
    }
}
