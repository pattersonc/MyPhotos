using System;
using System.IO;

namespace MyPhotos.Core.Util
{
    public static class RandomFileNameFactory
    {
        public static string GetRandomFileName(string path, string ext)
        {
            var fileName = Guid.NewGuid().ToString() + "." + ext;
            return Path.Combine(path, fileName);
        }
    }
}