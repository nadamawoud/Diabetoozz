using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class ChatbotQuestionCasualUser
    {
        public int ChatbotQuestionCasualUserID { get; set; }
        public string ChatbotQuestionCasualUserText { get; set; }

        // Foreign Key to Admin (Optional)
        public int? AdminID { get; set; }

        // Navigation Property (Should be nullable)
        public Admin? Admin { get; set; }

        // Foreign Key to CasualUser (Required)
        public int CasualUserID { get; set; }

        // Navigation Property for CasualUser
        public CasualUser CasualUser { get; set; }
    }
}