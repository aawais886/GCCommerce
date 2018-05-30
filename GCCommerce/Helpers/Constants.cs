using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCommerce.Helpers
{
    public class Constants
    {
        public static int PREVIOUS_YEAR = DateTime.Now.Year - 1;
        public static int CURRENT_YEAR = DateTime.Now.Year;
        public static int NEXT_YEAR = DateTime.Now.Year + 1;
        public static string UPDATED = "updated";
        public static string SAVED = "saved";
        public static string FAILED = "failed";
        public static string DELETE = "delete";
        public static string INFO = "info";
        public static string WARNING = "warning";
    }
}
