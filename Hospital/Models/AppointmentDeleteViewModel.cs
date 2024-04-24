using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class AppointmentDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Patient")]
        public string PatientName { get; set; }

        [Display(Name = "Doctor")]
        public string DoctorName { get; set; }

        [Display(Name = "Appointment Type")]
        public string AppointmentType { get; set; }

        [Display(Name = "Appointment Status")]
        public string AppointmentStatus { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; }
    }
}