using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPhotos.Core.Service;

namespace MyPhotos.Test.IntegrationTests
{
    [TestClass]
    public class FileStoreTests
    {
        private IFileStoreService _fileStoreService;
        
        public FileStoreTests()
        {
        }

        [TestMethod]
        public void Test_Save()
        {
            var test =
                Assembly.GetExecutingAssembly().GetManifestResourceStream("MyPhotos.Tests.IntegrationObjs.Desert.jpg");

            var fileService = new FileStoreService();

            var fi = fileService.SaveNew(test);

            Assert.IsTrue(new FileInfo(fi).Exists);
        }


        [TestMethod]
        public void CreateThumbnail()
        {
            var test =
                Assembly.GetExecutingAssembly().GetManifestResourceStream("MyPhotos.Tests.IntegrationObjs.Desert.jpg");

            var fileService = new FileStoreService();

            var fi = fileService.SaveNew(test);

            var thumb = fileService.CreateThumbnail(fi);

            Assert.IsTrue(new FileInfo(thumb).Exists);
        }
    }
}