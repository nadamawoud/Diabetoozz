using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Core.Entities
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation Property
        public int AdminID { get; set; }
        public Admin Admin { get; set; } 
        // relation many
        public virtual ICollection<NewsFeedPost> NewsFeedPosts { get; set; } = new List<NewsFeedPost>();


    }
}
