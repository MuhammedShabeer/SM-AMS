using System.ComponentModel.DataAnnotations;
namespace SM_AMS.Models
{
    public class CMastersModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "code is required")]
        public string? code { get; set; }

        [Required(ErrorMessage = "name is required")]
        public string? Name { get; set; }
    }
}
