using System.Collections.Generic;

namespace InforceUrll.Models
{
    public class User
    {
        public int Id { get; set; }
    
        public string Email { get; set; }
    
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        
        public List<ShortUrl> ShortUrls { get; set; }

        public User()
        {
            ShortUrls = new List<ShortUrl>();
        }
    }
}