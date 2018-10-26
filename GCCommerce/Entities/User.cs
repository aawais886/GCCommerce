using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCCommerce.Entities
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Your Email" )]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Your Password")]
        public string Password { get; set; }
        public string Gander { get; set; }
        public string Image { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
