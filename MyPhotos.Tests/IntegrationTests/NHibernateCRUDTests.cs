using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPhotos.Core.Data.NHibernate;
using MyPhotos.Core.Model;
using MyPhotos.Core.Service;
using NHibernate;
using NHibernate.Linq;

namespace MyPhotos.Test.IntegrationTests
{
    /// <summary>
    /// Summary description for NHibernateCRUDTests
    /// </summary>
    [TestClass]
    public class NHibernateCRUDTests
    {
        private ISessionFactory _sessionFactory;

        public NHibernateCRUDTests()
        {
            //
            // TODO: Add constructor logic here
            //
            _sessionFactory = SessionFactoryFactory.CreateSessionFactory();

            AddTestData();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //

        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
         public static void MyClassInitialize(TestContext testContext)
        {
            // recreate db for fresh start
            SessionFactoryFactory.DropSchema();
            SessionFactoryFactory.CreateSchema();
        }
        
        public void AddTestData()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var album = new Album()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Samples"
                };


                var photo1 = new Photo()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "Desert",
                    Album = album,
                    Filename = "desert.jpg",
                    ThumbFilename = "desert_thumb.jpg"

                };

                var photo2 = new Photo()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "Lighthouse",
                    Album = album,
                    Filename = "lighthouse.jpg",
                    ThumbFilename = "lighthouse_thumb.jpg"
                };

                var photo3 = new Photo()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "Penguins",
                    Album = album,
                    Filename = "penguins.jpg",
                    ThumbFilename = "penguins_thumb.jpg"
                };

                album.Photos = new List<Photo>() { photo1, photo2, photo3};
                album.CoverPhoto = photo1;

                var tag = new Tag()
                {
                    Name = "Sample"
                };

                if (photo1.Tags == null) photo1.Tags = new List<Tag>() { tag };
                if (photo2.Tags == null) photo2.Tags = new List<Tag>() { tag };
                if (photo3.Tags == null) photo3.Tags = new List<Tag>() { tag };

                session.SaveOrUpdate(album);
                session.Flush();
            
            }

        }

        [TestMethod]
        public void CanRetrieveData()
        {
            using(var session = _sessionFactory.OpenSession())
            {
                var album = (from p in session.Linq<Album>()
                            where p.Name == "Samples"
                            select p).Single();

                Assert.IsNotNull(album);
                Assert.AreEqual("Samples", album.Name);
                Assert.IsTrue(album.Photos.Count > 0);
                Assert.IsTrue(album.Photos.First().Tags.Count > 0);
            }
        }
    }
}
