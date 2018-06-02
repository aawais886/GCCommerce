using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GCCommerce.Models
{
    public class ModelProgram
    {
        [Key]
        public int ProgramId { get; set; }
        [Required]
        public int? FkShiftId { get; set; }
        [Required(ErrorMessage ="Select Program Title")]
        [Display(Name ="Program Title")]
        public string ProgramTitle { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
