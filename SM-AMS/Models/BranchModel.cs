using System.ComponentModel.DataAnnotations;
namespace SM_AMS.Models
{
    public class BranchModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Branch code is required")]
        public string code { get; set; } = "";

        [Required(ErrorMessage = "Branch name is required")]
        public string Name { get; set; } = "";
    }
}
