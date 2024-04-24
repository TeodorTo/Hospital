using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Patient")]
        public string PatientName { get; set; } = null!;

        [Display(Name = "Doctor")]
        public string DoctorName { get; set; } = null!;

        [Display(Name = "Type")]
        public string AppointmentType { get; set; } = null!;

        [Display(Name = "Status")]
        public string AppointmentStatus { get; set; } = null!;

        public string Reason { get; set; } = null!;
    }
}