using MyPhotos.Core.Model;

namespace MyPhotos.WebUI.ViewModel
{
    public class PhotoDetailViewModel
    {
        public PhotoDetailViewModel(Photo photo, Photo next, Photo prev)
        {
            CurrentPhoto = photo;
            NextPhoto = next;
            PrevPhoto = prev;
        }

        public Photo CurrentPhoto { get; set; }
        public Photo NextPhoto { get; set; }
        public Photo PrevPhoto { get; set; }

    }
}