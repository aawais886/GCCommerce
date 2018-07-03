using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GCCommerce.Models
{
    public class ModelEvent
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(40)]
        [Display(Name = "Event name")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Event Description is required.")]
        [StringLength(500)]
        [Display(Name = "Event Description")]
        [DataType(DataType.MultilineText)]
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
