using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class BloodSugarMeasurement
    {
        public int MeasurementID { get; set; }
        public int CasualUserID { get; set; } // Foreign Key to CasualUser
        public string MeasurementPeriod { get; set; }
        public decimal GlucoseLevel { get; set; }
        public DateTime MeasurementDate { get; set; }
        public string Notes { get; set; }

        // Navigation Property for CasualUser
        public CasualUser CasualUser { get; set; }
    }
}
