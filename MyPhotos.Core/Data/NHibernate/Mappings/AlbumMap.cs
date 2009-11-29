<<<<<<< HEAD
using System;
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
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
<<<<<<< HEAD
            Map(x => x.Name).Unique().Not.Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
            Map(x => x.ModifiedDate).Not.Nullable();
            HasMany(x => x.Photos).KeyColumn("AlbumID").Cascade.All();
            References(x => x.CoverPhoto).Column("CoverPhotoID");
=======
            Map(x => x.Name).Unique();
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedDate);
            HasMany(x => x.Photos).KeyColumn("AlbumID");
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        }
    }
}