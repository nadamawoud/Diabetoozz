using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        //Relations many to 1
        public int ClerkID { get; set; } // Foreign Key to Clerk
        public Clerk Clerk { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        //Relation 1 to 1

        public Diagnosis Diagnosis { get; set; }
        
        public SuggestionFood SuggestionFood { get; set; }
    }
}
