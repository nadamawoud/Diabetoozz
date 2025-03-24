using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class CasualUser
    {
        public int CasualUserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }


        // Foreign Key
        public int AdminID { get; set; }

        // Navigation Property
        public Admin Admin { get; set; } // العلاقة مع Admin

        //Relation Many
        public virtual ICollection<Alarm> Alarms { get; set; } = new List<Alarm>();
        public virtual ICollection<BloodSugarMeasurement> BloodSugarMeasurements { get; set; }= new List<BloodSugarMeasurement>();
        public virtual ICollection<Symptoms> Symptoms { get; set;  } = new List<Symptoms>();
        public virtual ICollection<ChatbotQuestionCasualUser> ChatbotQuestionCasualUsers { get; set; } = new List<ChatbotQuestionCasualUser>();
        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    }
}
