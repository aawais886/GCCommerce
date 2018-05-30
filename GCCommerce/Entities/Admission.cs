using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class Admission
    {
        public int AdmissionId { get; set; }
        public int FkProgramId { get; set; }
        public string AdmissionEligibilityCriteria { get; set; }
        public string AdmissionDocument { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Program FkProgram { get; set; }
    }
}
