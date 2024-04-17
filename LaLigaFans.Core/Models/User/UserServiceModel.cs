using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LaLigaFans.Core.Models.User
{
    public class UserServiceModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Orders Count")]
        public int OrdersCount { get; set; }

        public bool IsPublisher { get; set; }
    }
}
