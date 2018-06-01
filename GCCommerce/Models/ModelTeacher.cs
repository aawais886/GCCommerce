using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelTeacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(40)]
        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please enter a valid name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(40)]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please enter a valid name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email Is Required")]
        [Display(Name ="Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teacher's Grade")]
        public string Grade { get; set; }

        [Required(ErrorMessage = "Please enter teacher's qualifications.")]
        [Display(Name = "Qualifications")]
        [DataType(DataType.MultilineText)]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Please enter joining date.")]
        [Display(Name = "Joining date")]
        public DateTime HiredDate { get; set; }

        [Required(ErrorMessage = "Please enter Transfer date.")]
        [Display(Name = "Transfer date")]
        public DateTime? TransferDate { get; set; }

        [Required(ErrorMessage = "Please enter Retirement date.")]
        [Display(Name = "Retirement date")]
        public DateTime? RetirementDate { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
