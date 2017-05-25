using System.ComponentModel.DataAnnotations;

namespace AccountSystem.Web.Features.Account.Models
{
    public class NeedPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }
    }
}
