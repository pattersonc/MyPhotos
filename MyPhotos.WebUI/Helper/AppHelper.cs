using System.Web;
using System.Web.Mvc;
using MyPhotos.Core.Service;

namespace MyPhotos.WebUI.Helper
{
    public static class AppHelper
    {
        public static string ImgageUrl(this HtmlHelper helper, string fileName)
        {
            return VirtualPathUtility.ToAbsolute("/" + FileStoreService.RelativePath + fileName);
        }
    }
}