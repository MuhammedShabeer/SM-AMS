using System.Collections.Generic;
namespace SM_AMS.Models
{
    public class UserManagmentModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Branch { get; set; }
        public string? UserType { get; set; }
        public List<BranchModel> BranchList { get; set; }
        public List<string> UserTypeList { get; set; }
        public UserManagmentModel()
        {
            BranchList = new List<BranchModel>
            {
                new BranchModel { Id = 1, code = "A", Name = "Algiers" },
                new BranchModel { Id = 2, code = "O", Name = "Oran" },
                new BranchModel { Id = 3, code = "C", Name = "Constantine" }
            };

            UserTypeList = new List<string>
            {
                "Admin",
                "User",
            };
        }

    }
}
