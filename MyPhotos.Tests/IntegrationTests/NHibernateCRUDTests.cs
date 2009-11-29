using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPhotos.Core.Data.NHibernate;
using MyPhotos.Core.Model;
<<<<<<< HEAD
using MyPhotos.Core.Service;
using NHibernate;
using NHibernate.Linq;

namespace MyPhotos.Test.IntegrationTests
=======
using NHibernate;
using NHibernate.Linq;

namespace MyPhotos.Tests
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
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
<<<<<<< HEAD
            SessionFactoryFactory.CreateSchema();
=======
            SessionFactoryFactory.CreateSchema();           
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        }
        
        public void AddTestData()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var album = new Album()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
<<<<<<< HEAD
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

=======
                    Name = "MyAlbum"
                };


                var photo = new Photo()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "MyPhoto",
                    Album = album
                };

                var tags = new List<Tag>();

                for (int i = 1; i <= 5; i++)
                    tags.Add(new Tag() { Name = "Tag" + i });

                photo.Tags = tags;

                session.SaveOrUpdate(album);
                session.SaveOrUpdate(photo);
                session.Flush();
            }
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        }

        [TestMethod]
        public void CanDataAndRetrieveData()
        {


            using(var session = _sessionFactory.OpenSession())
            {
                var album = (from p in session.Linq<Album>()
<<<<<<< HEAD
                            where p.Name == "Samples"
                            select p).Single();

                Assert.IsNotNull(album);
                Assert.AreEqual("Samples", album.Name);
                Assert.IsTrue(album.Photos.Count > 0);
                Assert.IsTrue(album.Photos.First().Tags.Count > 0);
=======
                            where p.Name == "MyAlbum"
                            select p).Single();

                Assert.IsNotNull(album);
                Assert.AreEqual("MyAlbum", album.Name);
                Assert.AreEqual(1, album.Photos.Count);
                Assert.AreEqual("MyPhoto", album.Photos.Single().Description);
                Assert.IsNotNull(album.Photos.Single().Tags);
                Assert.AreEqual(5, album.Photos.Single().Tags.Count);
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
            }
        }
    }
}
