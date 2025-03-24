using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Alarm
    {
        public int AlarmID { get; set; }
        public int CasualUserID { get; set; } // Foreign Key to CasualUser
        public string AlarmType { get; set; }
        public DateTime AlarmTime { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Property for CasualUser
        public CasualUser CasualUser { get; set; }
    }
}
