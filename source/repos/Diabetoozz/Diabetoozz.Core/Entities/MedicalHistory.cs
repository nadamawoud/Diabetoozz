using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class MedicalHistory
    {
        public int MedicalHistoryID { get; set; }
        public string Diagnosis { get; set; }
        public string ChatbotData { get; set; }
        public DateTime DiagnosisDate { get; set; }
        //علاقه الادمن
        public int AdminID { get; set; }
        public Admin Admin { get; set; }

        //علاقه الدكتور
        public int DoctorID { get; set; } // Foreign Key to Doctor
        public Doctor Doctor { get; set; }
        //علاقه الmanger
        public int ManagerID { get; set; }
        public Manager Manager { get; set; }
    }
}
