using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GCCommerce.Models
{
    public class ModelProgram
    {
        [Key]
        public int ProgramId { get; set; }
        [Required]
        [Display(Name ="Select Shift")]
        public int? FkShiftId { get; set; }
        [Required(ErrorMessage ="Select Program Title")]
        [Display(Name ="Program Title")]
        [Remote("CheckDuplicate", "Administrator", HttpMethod = "Post", ErrorMessage = "Program Title already exit.")]
        public string ProgramTitle { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
