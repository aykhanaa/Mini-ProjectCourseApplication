using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User:BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email {get; set; }
        [Required]
        public string Password { get; set; }

    }
}
