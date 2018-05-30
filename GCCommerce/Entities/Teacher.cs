using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Grade { get; set; }
        public string Qualification { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? RetirementDate { get; set; }
        public string Image { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
