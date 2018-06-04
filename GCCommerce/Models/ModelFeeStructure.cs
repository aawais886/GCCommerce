using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelFeeStructure
    {
        [Key]
        public int Id { get; set; }
        public int FkProgramId { get; set; }

        [Required(ErrorMessage = "Select Shift")]
        public string Shift { get; set; }

        [Required(ErrorMessage = "Year1")]
        public double Year1 { get; set; }

        [Required(ErrorMessage = "Year2")]
        public double Year2 { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
