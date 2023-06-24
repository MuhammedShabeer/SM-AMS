using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SM_AMS.Models.EnumModel;
namespace SM_AMS.Models
{
    public class UserManagmentModel
    {
        public UserManagmentModel()
        {
            BranchList = new List<BranchModel>
            {
                new BranchModel { Id = 1, code = "A", Name = "Algiers" },
                new BranchModel { Id = 2, code = "O", Name = "Oran" },
                new BranchModel { Id = 3, code = "C", Name = "Constantine" }
            };
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Branch is required")]
        public int? Branch { get; set; }

        [Required(ErrorMessage = "User Type ID is required")]
        public int? UserTypeID { get; set; }

        public List<BranchModel> BranchList { get; set; }
        public enmUserType UserType { get; set; }

    }
}
