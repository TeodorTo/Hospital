using System.ComponentModel.DataAnnotations;
using static Hospital.Data.DataConstants;
namespace Hospital.Data;

public class Doctor
{
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(DoctorNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(DoctorSpecializationMaxLength)]
    public string Specialization { get; set; } = string.Empty;

    [Required]
    [MaxLength(DoctorOfficeMaxLength)]
    public string Office { get; set; } = string.Empty;

    [Required]
    [MaxLength(DoctorWorkingHoursMaxLength)]
    public string WorkingHours { get; set; } = string.Empty;

    public ICollection<DoctorPatient>? DoctorsPatients { get; set; } = new List<DoctorPatient>();
}