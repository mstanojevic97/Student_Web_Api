using System.ComponentModel.DataAnnotations;

namespace Student_Web_Api.Models.Domain
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Code")]
        public int Code { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum lenght is 2!")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum lenght is 2!")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
