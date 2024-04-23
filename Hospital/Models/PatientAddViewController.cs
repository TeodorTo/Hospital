using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class PatientAddViewModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "The Age field is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The Gender field is required.")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "The Address field is required.")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "The Phone Number field is required.")]
        public string PhoneNumber { get; set; } = null!;

        public string MedicalHistory { get; set; } = null!;

        public string AdditionalInformation { get; set; } = null!;
    }
}