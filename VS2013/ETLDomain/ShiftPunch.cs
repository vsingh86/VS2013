using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETLDomain
{
    public class ShiftPunch : Entity
    {
        public DateTime InDateTime { get; set; }
        public DateTime OutDateTime { get; set; }
        public string PunchReasonCode { get; set; }
        public string EarnCode { get; set; }
        public string ActivityCode { get; set; }
        
    }
}