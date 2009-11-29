using System;
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
            Map(x => x.Name).Unique().Not.Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
            Map(x => x.ModifiedDate).Not.Nullable();
            HasMany(x => x.Photos).KeyColumn("AlbumID").Cascade.All();
            References(x => x.CoverPhoto).Column("CoverPhotoID").Cascade.All().Not.Nullable();
        }
    }
}