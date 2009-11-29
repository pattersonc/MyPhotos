using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPhotos.Core.Model
{
    public class Album
    {
        public virtual int ID { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual IList<Photo> Photos { get; set; }
        public virtual Photo CoverPhoto { get; set; }
    }
}