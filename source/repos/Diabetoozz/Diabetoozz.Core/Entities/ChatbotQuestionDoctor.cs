using System;

namespace Diabetes.Core.Entities
{
    public class ChatbotQuestionDoctor
    {
        public int ChatbotQuestionDoctorID { get; set; }
        public string ChatbotQuestionDoctorText { get; set; }

        // Foreign Keys
        public int DoctorID { get; set; }
        public int AdminID { get; set; }

        // Navigation Properties
        public virtual Doctor Doctor { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
