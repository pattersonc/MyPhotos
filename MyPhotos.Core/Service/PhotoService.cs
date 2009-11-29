using MyPhotos.Core.Model;
using MyPhotos.Core.Repository;

namespace MyPhotos.Core.Service
{
    public interface IPhotoService
    {
        Photo GetById(long id);
    }

    public class PhotoService : IPhotoService
    {
        private IPhotoRepository _photoRepository;

        public PhotoService() : this(null)
        {
        }

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository ?? new PhotoRepository();
        }

        public Photo GetById(long id)
        {
            var photo = _photoRepository.GetById(id);

            return photo;
        }



        
    }
}