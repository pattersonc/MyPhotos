using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using MyPhotos.Core.Util;

namespace MyPhotos.Core.Service
{
    public interface IFileStoreService
    {
        string SaveNew(Stream inputSteam);
        List<FileInfo> GetAll();
    }

    public class FileStoreService : IFileStoreService
    {
        public static string RelativePath = "Content\\FileStore\\";
        public static int ThumbWidthPx = 200;

        protected string _storeLocation;
        public const int BufferSize = 32*1024;

        public FileStoreService(string storeLocation)
        {
            _storeLocation = storeLocation;

            var di = new DirectoryInfo(_storeLocation);
            
            if(!di.Exists)
                di.Create();
        }

        public FileStoreService() : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RelativePath))
        {
        }

        public string SaveNew(Stream inputSteam)
        {
            var fileInfo = new FileInfo(RandomFileNameFactory.GetRandomFileName(_storeLocation, "jpg"));

            if(fileInfo.Exists)
                throw new ApplicationException("File already exits.");
            
            Debug.WriteLine("Saving file: " + fileInfo.FullName);

            var fileStream = new FileStream(fileInfo.FullName, FileMode.Create);
            int bytesRead = 0;
            var buffer = new byte[BufferSize];

            try
            {
                do
                {
                    bytesRead = inputSteam.Read(buffer, 0, BufferSize);
                    fileStream.Write(buffer, 0, bytesRead);

                } while (bytesRead > 0);
            }
            finally
            {
                fileStream.Close();
                fileStream.Dispose();
            }

            return fileInfo.FullName;
        }

        public string CreateThumbnail(string fileName)
        {
            var fi = new FileInfo(fileName);

            if (!fi.Exists)
                throw new ArgumentException("File does not exist");

            string withoutExt = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);

            string thumbFileName = withoutExt + "_thumb" + ext;

            fi.CopyTo(thumbFileName);
            
            ImageUtil.ResizeImage(thumbFileName, ThumbWidthPx);

            return thumbFileName;
        }

        public List<FileInfo> GetAll()
        {
            var di = new DirectoryInfo(_storeLocation);

            return di.GetFiles().ToList();
        }


    }
}