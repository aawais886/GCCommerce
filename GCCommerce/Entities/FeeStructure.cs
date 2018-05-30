using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class FeeStructure
    {
        public int Id { get; set; }
        public int FkProgramId { get; set; }
        public string Shift { get; set; }
        public double Year1 { get; set; }
        public double Year2 { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Program FkProgram { get; set; }
    }
}
