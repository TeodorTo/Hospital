using static Hospital.Data.DataConstants;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Data;

public class Patient
{
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(PatientNameMaxLength)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public int Age { get; set; }
    
    [Required]
    [MaxLength(PatientGenderMaxLength)]
    public string Gender { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(PatientAddressMaxLength)]
    public string Address { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(PatientPhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [MaxLength(PatientMedicalHistoryMaxLength)]
    public string MedicalHistory { get; set; } = string.Empty;
    
    [MaxLength(PatientAdditionalInformationMaxLength)]
    public string AdditionalInformation { get; set; } = string.Empty;

    
    public virtual ICollection<Appointment> Appointments { get; set; } = null!;



}