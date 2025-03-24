using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorTitle { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string MedicalSyndicateCardNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string VerificationStatus { get; set; }
        public DateTime CreatedAt { get; set; }


        // Navigation Property
        public int AdminID { get; set; }
        public Admin Admin { get; set; } // العلاقة مع Admin

        // Navigation Property for MedicalSyndicate
        public int MedicalSyndicateID { get; set; } // Foreign Key to MedicalSyndicate
        public MedicalSyndicate MedicalSyndicate { get; set; }

        //Relation many
        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public virtual ICollection<ChatbotQuestionDoctor> ChatbotQuestionDoctors { get; set; } = new List<ChatbotQuestionDoctor>();
        public virtual ICollection<Clerk> Clerks { get; set; } =new List<Clerk>();
       

    }
}
