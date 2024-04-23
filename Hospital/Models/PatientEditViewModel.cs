using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class PatientEditViewModel : PatientAddViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}