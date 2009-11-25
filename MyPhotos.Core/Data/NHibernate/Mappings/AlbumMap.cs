using FluentNHibernate.Mapping;
using MyPhotos.Core.Model;

namespace MyPhotos.Core.Data.NHibernate.Mappings
{
    public class AlbumMap : ClassMap<Album>
    {
        public AlbumMap()
        {
            Table("Album");

            Id(x => x.ID);
            Map(x => x.Name).Unique();
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedDate);
            HasMany(x => x.Photos).KeyColumn("AlbumID");
        }
    }
}