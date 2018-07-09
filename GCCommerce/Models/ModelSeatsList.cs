using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Models
{
    public class ModelSeatsList
    {
        public int Id { get; set; }
        public string ProgramTitle{ get; set; }
        public int  TotalSeats{ get; set; }
        public int AvailAbleSeats{ get; set; }
        public int ReserveSeats{ get; set; }
      

    }
}
