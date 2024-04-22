using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Hospital.Data.DataConstants;

namespace Hospital.Data;

public class BillingRecord
{
    [Key]
    public int BillingRecordId { get; set; }

    [Required]
    public int AppointmentId { get; set; }

    [ForeignKey(nameof(AppointmentId))]
    public Appointment Appointment { get; set; } = null!;

    [Required]
    public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public virtual Patient Patient { get; set; } = null!;
   
    [Required]
    [Range(0.0,BillingRecordAmountMaxLenght)]
    public decimal Amount { get; set; }

    [Required]
    public DateTime BillingDate { get; set; }

    [MaxLength(BillingRecordNotesMaxLenght)]
    public string Notes { get; set; } = string.Empty;
}