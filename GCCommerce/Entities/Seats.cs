using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class Seats
    {
        public int SeatId { get; set; }
        public int FkProgramId { get; set; }
        public int SeatsTotal { get; set; }
        public int SeatsAvailable { get; set; }
        public int SeatsReserve { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Program FkProgram { get; set; }
    }
}
