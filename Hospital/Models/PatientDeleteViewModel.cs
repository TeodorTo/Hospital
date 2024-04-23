namespace Hospital.Models
{
    public class PatientDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string MedicalHistory { get; set; } = null!;
        public string AdditionalInformation { get; set; } = null!;
    }
}