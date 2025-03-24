using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Clerk
    {
        public int ClerkID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string LicenseCode { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }

        // Foreign Key
        public int AdminID { get; set; }
        public int DoctorID { get; set; }// Foreign Key

        // Navigation Property
        public Admin Admin { get; set; } // العلاقة مع Admin
        public Doctor Doctor { get; set; }
        //Relation many
        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
