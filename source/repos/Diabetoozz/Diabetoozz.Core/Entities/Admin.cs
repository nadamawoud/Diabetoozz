using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // العلاقة مع Organization (One-to-Many) - الإداري يمكن أن يكون مسؤولًا عن عدة منظمات
        public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

        // العلاقة مع Clerk (One-to-Many) - الإداري يمكن أن يكون مسؤولًا عن عدة موظفين
        public virtual ICollection<Clerk> Clerks { get; set; } = new List<Clerk>();

        // العلاقة مع Doctor (One-to-Many) - الإداري يمكن أن يكون مسؤولًا عن عدة أطباء
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

        // العلاقة مع CasualUser (One-to-Many) - الإداري يمكن أن يكون مسؤولًا عن عدة مستخدمين
        public virtual ICollection<CasualUser> CasualUsers { get; set; } = new List<CasualUser>();

        // العلاقة مع ChatbotQuestionCasualUser (One-to-Many) - الإداري يمكن أن يكون مسؤولًا عن عدة أسئلة
        public virtual ICollection<ChatbotQuestionDoctor> ChatbotQuestionDoctors { get; set; } = new List<ChatbotQuestionDoctor>();
        public virtual ICollection<ChatbotQuestionCasualUser> ChatbotQuestionCasualUsers { get; set; } = new List<ChatbotQuestionCasualUser>();

        public virtual ICollection<Manager> Managers { get; set; }= new List<Manager>();
        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

    }
}
