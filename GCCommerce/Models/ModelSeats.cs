using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelSeats
    {
        [Key]
        public int SeatId { get; set; }
        public int FkProgramId { get; set; }
        [Required]
        [Display(Name ="Total Seats")]
        public int SeatsTotal { get; set; }
        [Required]
        [Display(Name = "AvailAble Seats")]
        public int SeatsAvailable { get; set; }
        [Required]
        [Display(Name = "Reserve Seats")]
        public int SeatsReserve { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
