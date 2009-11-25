using System.Collections.Generic;

namespace MyPhotos.Core.Model
{
    public class Tag
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Photo> Photos { get; set; }

    }
}