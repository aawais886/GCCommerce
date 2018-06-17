using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelAdmission
    {
        [Key]
        public int AdmissionId { get; set; }

        public int FkProgramId { get; set; }
        [Required(ErrorMessage = " Admission Criteria required.")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Admission Eligibility Criteria")]
        public string AdmissionEligibilityCriteria { get; set; }
        [Required(ErrorMessage = "Admission Document is required.")]
        [StringLength(500)]
        [Display(Name = "Admission Document Value")]
        public string AdmissionDocument { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        
    }
}
