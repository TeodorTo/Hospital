using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(50, ErrorMessage = "The Name field must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "The Age field is required.")]
        [Range(1, 150, ErrorMessage = "Please enter a valid age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The Gender field is required.")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "The Address field is required.")]
        [StringLength(100, ErrorMessage = "The Address field must be at least {2} and at most {1} characters long.", MinimumLength = 5)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "The Phone Number field is required.")]
        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(500, ErrorMessage = "The Medical History field must be at most {1} characters long.")]
        public string MedicalHistory { get; set; } = null!;

        [StringLength(500, ErrorMessage = "The Additional Information field must be at most {1} characters long.")]
        public string AdditionalInformation { get; set; } = null!;
    }
}