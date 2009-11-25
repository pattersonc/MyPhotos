using System.Collections.Generic;
using System.Linq;

namespace MyPhotos.Core.Repository
{
    public interface IRepository<T>
    {
        void Save();
        IList<T> GetAll();
        T GetById(int id);
        void Add(T itemToAdd);
        void Add(IList<T> itemsToAdd);
        void Delete(T itemToDelete);
        void Delete(IList<T> itemsToDelete);
    }
}