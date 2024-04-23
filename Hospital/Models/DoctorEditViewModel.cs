
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Models
{
    public class DoctorEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "The Specialty field is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The Specialty must be between 2 and 100 characters.")]
        public string Specialty { get; set; } = null!;

        [Required(ErrorMessage = "The Office field is required.")]
        public string Office { get; set; } = null!;

        [Required(ErrorMessage = "The WorkingHours field is required.")]
        public string WorkingHours { get; set; } = null!;

        [Required(ErrorMessage = "Please select a department.")]
        public int SelectedDepartmentId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
    }
}