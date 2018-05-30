using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class Gallery
    {
        public int GalleryId { get; set; }
        public string GalleryImageName { get; set; }
        public string GalleryImageDescription { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
