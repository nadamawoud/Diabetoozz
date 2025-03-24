using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class NewsFeedPost
    {
        public int NewsFeedPostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public DateTime CreatedAt { get; set; }

        //relation
        public MedicalSyndicate MedicalSyndicate { get; set; }
        public int MedicalSyndicateID { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationID { get; set; }

    }
}
