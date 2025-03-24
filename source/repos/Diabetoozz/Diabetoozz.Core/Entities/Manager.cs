using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Foreign Key
        public int AdminID { get; set; }

        // Navigation Property for Admin
        public Admin Admin { get; set; }
        // relation many
        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; }= new List<MedicalHistory>();
    }
}
