namespace Hospital.Models
{
    public class DoctorDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public string Office { get; set; } = null!;
        public string WorkingHours { get; set; } = null!;
        public string Department { get; set; } = null!;
    }
}