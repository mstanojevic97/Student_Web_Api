using System.ComponentModel.DataAnnotations;

namespace Student_Web_Api.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum lengts is 2!")]
        [Display(Name = " Address")]
        public string Address { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum lengts is 2!")]
        [Display(Name = " City")]
        public string City { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum lengts is 2!")]
        [Display(Name = " State")]
        public string State { get; set; }
        [Required]
        [Display(Name = " Date of Birth")]
        public DateTime DateBirth { get; set; }
        public string Sex { get; set; }
    }
}
