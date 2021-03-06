﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelShift
    {
        [Key]
        public int ShiftId { get; set; }
        [Required(ErrorMessage = "Slect Shift")]
        [Remote("checkDuplicateShift", "Administrator", HttpMethod ="Post", ErrorMessage="Shift is Already exit.")]
        [Display(Name ="Shift")]
        public string Shift1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
