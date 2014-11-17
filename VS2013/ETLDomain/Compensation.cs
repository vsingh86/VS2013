using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETLDomain
{
    public class Compensation : Entity
    {
        public int EmployeeID { get; set; }
        public char CompFrequency { get; set; }
        public float CompRate { get; set; }
        public Single ChangeAmount { get; set; }
        public Single ChangePercent { get; set; }
    }
}