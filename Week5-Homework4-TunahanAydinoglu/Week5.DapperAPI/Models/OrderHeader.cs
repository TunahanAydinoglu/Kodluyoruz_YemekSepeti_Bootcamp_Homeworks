using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.DapperAPI.Models
{
    public class OrderHeader
    {
        public int PurchaseOrderID { get; set; }
        public int EmployeeID { get; set; }
        public int Status { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
