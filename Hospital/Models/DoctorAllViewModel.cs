

namespace Hospital.Models
{
    public class DoctorAllViewModel
    {
        public DoctorAllViewModel(
            int id,
            string name,
            string specialty,
            string departmentName // Add departmentName property
        )
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            DepartmentName = departmentName; // Assign department name
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string DepartmentName { get; set; } // Add department name property
    }
}