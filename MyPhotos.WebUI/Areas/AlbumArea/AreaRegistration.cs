using System.Web.Mvc;

namespace MyPhotos.WebUI.Areas.AlbumArea
{
    public class AlbumAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AlbumArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AlbumArea_default",
                "AlbumArea/{controller}/{action}/{id}",
                new { action = "Index", id = "" }
            );
        }
    }
}
