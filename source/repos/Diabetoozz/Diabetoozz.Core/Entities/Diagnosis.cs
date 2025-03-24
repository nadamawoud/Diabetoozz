using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Diagnosis
    {
        public int DiagnosisID { get; set; }
        public string Symptoms { get; set; }
        public string LabResults { get; set; }
        public string DiagnosisResult { get; set; }
        public string SuggestedLifestyle { get; set; }
        public DateTime DiagnosisDate { get; set; }

        // Foreign Key
        public int PatientID { get; set; }

        // Navigation Property for Patient (One-to-One)
        public Patient Patient { get; set; }
        public int DiseaseID { get; set; }
        public Disease Disease { get; set; }//relation 1 to 1
    }
}
