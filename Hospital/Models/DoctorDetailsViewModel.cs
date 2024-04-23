using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class DoctorDetailsViewModel
    {
        public DoctorDetailsViewModel(
            int id,
            string name,
            string specialty,
            string departmentName,
            string office,
            string workingHours
        )
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            DepartmentName = departmentName;
            Office = office;
            WorkingHours = workingHours;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public string DepartmentName { get; set; }

        public string Office { get; set; }

        public string WorkingHours { get; set; }
    }
}