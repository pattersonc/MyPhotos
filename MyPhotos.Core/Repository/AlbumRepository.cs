using System.Collections.Generic;
using System.Linq;
using MyPhotos.Core.Model;
using NHibernate.Linq;

namespace MyPhotos.Core.Repository
{
    public interface IAlbumRepository
    {
        Album GetById(int id);
        void Add(Album entity);
        void Add(IList<Album> entities);
        void Update(Album entity);
        IList<Album> GetAll();
        void Delete(Album entity);
        void Delete(IList<Album> entities);
        void Save();
    }

    public class AlbumRepository : NHibernateRepositoryBase<Album>, IAlbumRepository
    {
        Album GetByName(string name)
        {
            return _session.Linq<Album>().Where(p => p.Name == name).Single();
        }
    }
}