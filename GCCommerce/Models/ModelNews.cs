using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GCCommerce.Models
{
    public class ModelNews
    {
        [Key]
        public int NewsId { get; set; }
        [Required(ErrorMessage = "News Value is required.")]
        [StringLength(500)]
        [Display(Name = "News Value")]
        [DataType(DataType.MultilineText)]
        public string NewsValue { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
