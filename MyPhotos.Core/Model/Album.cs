using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba

namespace MyPhotos.Core.Model
{
    public class Album
    {
        public virtual int ID { get; set; }
<<<<<<< HEAD
        [Required]
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        public virtual string Name { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual IList<Photo> Photos { get; set; }
<<<<<<< HEAD
        public virtual Photo CoverPhoto { get; set; }
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
    }
}