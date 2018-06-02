using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelProgram
    {
        public int ProgramId { get; set; }
        public int? FkShiftId { get; set; }
        public string ProgramTitle { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
