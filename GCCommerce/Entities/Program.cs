using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class Program
    {
        public Program()
        {
            Admission = new HashSet<Admission>();
            FeeStructure = new HashSet<FeeStructure>();
            MeritList = new HashSet<MeritList>();
            Seats = new HashSet<Seats>();
        }

        public int ProgramId { get; set; }
        public int? FkShiftId { get; set; }
        public string ProgramTitle { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Shift FkShift { get; set; }
        public ICollection<Admission> Admission { get; set; }
        public ICollection<FeeStructure> FeeStructure { get; set; }
        public ICollection<MeritList> MeritList { get; set; }
        public ICollection<Seats> Seats { get; set; }
    }
}
