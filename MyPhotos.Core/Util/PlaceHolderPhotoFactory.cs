using System;
using MyPhotos.Core.Model;

namespace MyPhotos.Core.Util
{
    public static class PlaceHolderPhotoFactory
    {
        public static Photo GetPlaceHolderPhoto()
        {
            return new Photo()
                       {
                           Album = null,
                           CreatedDate = DateTime.MinValue,
                           ModifiedDate = DateTime.MinValue,
                           Description = "",
                           Filename = "placeholder.jpg",
                           ID = 0
                       };
        }
    }
}