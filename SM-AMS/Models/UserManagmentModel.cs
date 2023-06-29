using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SM_AMS.Models.EnumModel;
namespace SM_AMS.Models
{
    public class UserManagmentModel
    {
        public UserManagmentModel()
        {
            BranchList = new List<CMastersModel>
            {
                new CMastersModel { Id = 1, code = "A", Name = "Algiers" },
                new CMastersModel { Id = 2, code = "O", Name = "Oran" },
                new CMastersModel { Id = 3, code = "C", Name = "Constantine" }
            };
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Branch is required")]
        public int? BranchID { get; set; }
        public string? Branch { get; set; }

        public List<CMastersModel> BranchList { get; set; }

        [Required(ErrorMessage = "User Type is required")]
        public enmUserType UserType { get; set; }

    }
}
