using System;
using System.ComponentModel.DataAnnotations;
using Hospital.Data;
using static Hospital.Data.DataConstants;

namespace Hospital.Models
{
    public class AppointmentAddViewModel
    {
        
        [Required]
        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Appointment Type")]
        public int AppointmentTypeId { get; set; }

        [Required]
        [Display(Name = "Appointment Status")]
        public int AppointmentStatusId { get; set; } 

        [MaxLength(AppointmentReasonMaxLenght)]
        public string Reason { get; set; } = null!;
    }
}