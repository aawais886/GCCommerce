using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelMeritListList
    {
        public int ID { get; set; }
        public int FKProgramID { get; set; }
        public string ProgramTitle{ get; set; }
        public string Shift { get; set; }
        public string MeritListValue { get; set; }
    }
}
