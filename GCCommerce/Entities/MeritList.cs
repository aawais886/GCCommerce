using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class MeritList
    {
        public int MeritListId { get; set; }
        public int FkProgramId { get; set; }
        public string Shift { get; set; }
        public string MeritListValue { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Program FkProgram { get; set; }
    }
}
