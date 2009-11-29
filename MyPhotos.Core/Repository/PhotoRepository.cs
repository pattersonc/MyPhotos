using System;
using System.Collections.Generic;
using System.Linq;
using MyPhotos.Core.Model;

namespace MyPhotos.Core.Repository
{
    public interface IPhotoRepository
    {
        IList<Photo> GetAll();
        Photo GetById(long id);
        void Add(Photo entity);
        void Add(IList<Photo> entities);
        void Update(Photo entity);
        void Delete(Photo entity);
        void Delete(IList<Photo> entities);
        void Save();
    }

    public class PhotoRepository : NHibernateRepositoryBase<Photo>, IPhotoRepository
    {
        public override Photo GetById(int id)
        {
            throw new NotSupportedException("Use method GetById(long id)");
        }

        public Photo GetById(long id)
        {
            return _session.Get<Photo>(id);
        }
    }
}