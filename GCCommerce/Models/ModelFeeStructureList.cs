using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelFeeStructureList
    {
        public int  Id { get; set; }
        public string FkProgramId { get; set; }
        public string ProgramTitle { get; set; }
        public string Shift { get; set; }
        public double Year1 { get; set; }
        public double Year2 { get; set; }


    }
}
