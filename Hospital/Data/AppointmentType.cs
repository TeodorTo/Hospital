using System.ComponentModel.DataAnnotations;
using static Hospital.Data.DataConstants;
namespace Hospital.Data;

public class AppointmentType
{
    [Key]
    public int AppointmentTypeId { get; set; }

    [Required]
    [MaxLength(AppointmentTypeNameMaxLenght)]
    public string Name { get; set; } = String.Empty;

    [MaxLength(AppointmentTypeDescMaxLenght)]
    public string Description { get; set; } = String.Empty;
    
    
}