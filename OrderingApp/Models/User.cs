using System.ComponentModel.DataAnnotations;

namespace OrderingApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class UserVM
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}