﻿using Ewig;
// TDD (Test-Driven-Development)
// Attribute
// Reflection


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Ewig.UnitTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void 양수와_양수를_더하면_합계를_반환하여야_함()
        {
            int sum = Program.Add(1, 2);

            Assert.AreEqual(3, sum);
        }

        [TestMethod]
        public void 음수와_음수를_더하면_합계를_반환하여야_함()
        {
            int sum = Program.Add(-1, -2);

            Assert.AreEqual(-3, sum);
        }

        [TestMethod]
        public void Album_GetCountTest()
        {
            int count = Program.Album_GetCount();
            
            Assert.AreEqual(347, count);
        }

        [TestMethod()]
        public void Album_GetByPKTest()
        {
            Album album = Program.Album_GetByPK(1);
            
            Assert.AreEqual("For Those About To Rock We Salute You", album.Title);
            Assert.AreEqual(1, album.ArtistId);
        }

        [TestMethod()]
        public void Album_GetAllPKTest()
        {
            List<Album> albums = Program.Album_GetAll();

            Assert.AreEqual(347, albums.Count);
            
            Assert.AreEqual("For Those About To Rock We Salute You", albums[0].Title);
            Assert.AreEqual(1, albums[0].ArtistId);
        }

        [TestMethod()]
        public void Album_InsertTest()
        {
            int oldCount = Program.Album_GetCount();

            Album album = new Album();
            album.Title = DateTime.Now.ToString();
            album.ArtistId = 1;

            Program.Album_Insert(album);

            int newCount = Program.Album_GetCount();

            Assert.AreEqual(oldCount + 1, newCount);
        }
    }
}
