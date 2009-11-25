using FluentNHibernate.Mapping;
using MyPhotos.Core.Model;

namespace MyPhotos.Core.Data.NHibernate.Mappings
{
    public class TagMap : ClassMap<Tag>
    {
        public TagMap()
        {
            Table("Tag");

            Id(x => x.ID);
            Map(x => x.Name).Unique();
            HasManyToMany(x => x.Photos).Cascade.All().Inverse().Table("PhotoTag");
        }
    }
}