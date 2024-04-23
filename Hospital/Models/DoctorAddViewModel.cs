using System.ComponentModel.DataAnnotations;
using static Hospital.Data.DataConstants;

namespace Hospital.Models
{
    public class DoctorAddViewModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(DoctorNameMaxLength, MinimumLength = DoctorNameMinLength,
            ErrorMessage = "The Name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "The Specialty field is required.")]
        [StringLength(DoctorSpecialtyMaxLength, MinimumLength = DoctorSpecialtyMinLength,
            ErrorMessage = "The Specialty must be between {2} and {1} characters.")]
        public string Specialty { get; set; } = null!;
        
        
        [Required]
        
        public string Office { get; set; } = null!;
        
        [Required]
        
        public string WorkingHours { get; set; } = null!;

        [Required]
        public int DepartmentId { get; set; }
        public IEnumerable<DepartmentsViewModel> Departments { get; set; } = new List<DepartmentsViewModel>();
        
    }
}