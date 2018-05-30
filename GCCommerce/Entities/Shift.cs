using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class Shift
    {
        public Shift()
        {
            Program = new HashSet<Program>();
        }

        public int ShiftId { get; set; }
        public string Shift1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<Program> Program { get; set; }
    }
}
