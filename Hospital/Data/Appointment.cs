using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Hospital.Data.DataConstants;

namespace Hospital.Data;

public class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;

    [Required]
    public int DoctorId { get; set; }

    [ForeignKey(nameof(DoctorId))]
    public Doctor Doctor { get; set; } = null!;

    [Required]
    public int AppointmentTypeId { get; set; }

    [ForeignKey(nameof(AppointmentTypeId))]
    public AppointmentType AppointmentType { get; set; } = null!;

    [Required]
    public int AppointmentStatusId { get; set; }

    [ForeignKey(nameof(AppointmentStatusId))]
    public AppointmentStatus AppointmentStatus { get; set; } = null!;

    [MaxLength(AppointmentReasonMaxLenght)]
    public string Reason { get; set; } = string.Empty;
}