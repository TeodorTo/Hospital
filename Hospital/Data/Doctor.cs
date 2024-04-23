using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.Operations;
using static Hospital.Data.DataConstants;
namespace Hospital.Data;

public class Doctor
{
    [Key] 
    public int DoctorId { get; set; }

    [Required]
    [MaxLength(DoctorNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(DoctorSpecialtyMaxLength)]
    public string Specialty { get; set; } = string.Empty;

    [Required]
    [MaxLength(DoctorOfficeMaxLength)]
    public string Office { get; set; } = string.Empty;

    [Required]
    [MaxLength(DoctorWorkingHoursMaxLength)]
    public string WorkingHours { get; set; } = string.Empty;

    [Required]
    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))] 
    public Department Department { get; set; } = null!;
    
}