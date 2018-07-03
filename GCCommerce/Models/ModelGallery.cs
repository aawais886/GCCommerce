using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GCCommerce.Models
{
    public class ModelGallery
    {
        [Key]
        public int GalleryId { get; set; }
        [Required(ErrorMessage = "Image name is required.")]
        [StringLength(40)]
        [Display(Name = "Image name")]
        public string GalleryImageName { get; set; }
        [Required(ErrorMessage = "Image Description is required.")]
        [StringLength(200)]
        [Display(Name = "Image Description")]
        [DataType(DataType.MultilineText)]
        public string GalleryImageDescription { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
