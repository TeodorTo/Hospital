using System.ComponentModel.DataAnnotations;
using static Hospital.Data.DataConstants;

namespace Hospital.Data;

public class AppointmentStatus
{
    [Key]
    public int AppointmentStatusId { get; set; }

    [Required] 
    [MaxLength(AppointmentStatusMaxNameLenght)]
    public string Name { get; set; } = string.Empty;
}