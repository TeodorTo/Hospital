using System.ComponentModel.DataAnnotations;
using static Hospital.Data.DataConstants;

namespace Hospital.Data;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required] 
    [MaxLength(DepartmentNameMaxLenght)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(DepartmentDescMaxLenght)]
    public string Description { get; set; } = string.Empty;

    public virtual IEnumerable<Doctor> Doctors { get; set; } = new List<Doctor>();
}