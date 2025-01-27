using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLogin.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Please enter valid user name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter valid Email ")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
