using FluentNHibernate.Mapping;
using MyPhotos.Core.Model;

namespace MyPhotos.Core.Data.NHibernate.Mappings
{
    public class PhotoMap : ClassMap<Photo>
    {
        public PhotoMap()
        {
            Table("Photo");

            Id(x => x.ID);
            Map(x => x.Description);
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedDate);
<<<<<<< HEAD
            Map(x => x.Filename).Not.Nullable();
            Map(x => x.ThumbFilename).Not.Nullable();
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
            References(x => x.Album).Column("AlbumID");
            HasManyToMany(x => x.Tags).Cascade.All().Table("PhotoTag");
        }
    }
}