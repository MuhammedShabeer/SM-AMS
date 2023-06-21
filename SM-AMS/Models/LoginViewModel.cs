using System.ComponentModel.DataAnnotations;
namespace SM_AMS.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Branch is required")]
        public int BranchID { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }

}
