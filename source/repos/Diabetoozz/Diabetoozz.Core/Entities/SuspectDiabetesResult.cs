using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class SuspectDiabetesResult
    {
        public int SuspectResultID { get; set; }
        public string RiskLevel { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string Recommendation { get; set; }
        // relation many
        public virtual ICollection<Symptoms> Symptoms { get; set; } = new List<Symptoms>();
    }
}
