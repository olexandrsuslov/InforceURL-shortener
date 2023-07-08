using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InforceUrll.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        
        [Required]
        public string OriginalUrl { get; set; }
        
        [Required]
        public string ShortenedUrl { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}