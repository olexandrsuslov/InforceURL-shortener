using System.ComponentModel.DataAnnotations;

namespace InforceUrll.Models.ViewModels
{
    public class UrlViewModel
    {
        [Required]
        public string OriginalUrl { get; set; }
    }
}