using System;
using System.Collections.Generic;

namespace MyPhotos.Core.Model
{
    public class Photo
    {
        public virtual long ID { get; set; }
        public virtual Album Album { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Filename { get; set; }
        public virtual string ThumbFilename { get; set; }
    }
}