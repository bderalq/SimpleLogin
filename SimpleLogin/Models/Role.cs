    using System.ComponentModel.DataAnnotations;
namespace SimpleLogin.Models

{
    public class Role
    {
        [Display(Name ="Role ID ")]
        public int RoleId { get; set; }
    [Display(Name = "Role Name ")]
    [Required(ErrorMessage ="Please Input Role Name")]
    public string RoleName { get; set; }
    }
}
