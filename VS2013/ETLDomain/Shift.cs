using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETLDomain
{
    public class Shift : Entity
    {
        public int EmployeeID { get; set; }
        public DateTime ShiftDate { get; set; }
        public Single TotalHours { get; set; }
        public char Status { get; set; }

        public virtual List<ShiftPunch> Punches { get; set; }
    }
}