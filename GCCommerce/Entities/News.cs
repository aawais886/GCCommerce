using System;
using System.Collections.Generic;

namespace GCCommerce.Entities
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string NewsValue { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
