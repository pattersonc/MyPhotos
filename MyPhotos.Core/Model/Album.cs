using System;
using System.Collections.Generic;

namespace MyPhotos.Core.Model
{
    public class Album
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual IList<Photo> Photos { get; set; }
    }
}