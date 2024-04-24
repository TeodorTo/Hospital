// AppointmentEditViewModel
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hospital.Data;

namespace Hospital.Models
{
    public class AppointmentEditViewModel
    {
        public int Id { get; set; }

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

        [MaxLength(200)] 
        public string Reason { get; set; } = null!;

        // Define these properties to hold the lists of patients, doctors, appointment types, and appointment statuses
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<AppointmentType> AppointmentTypes { get; set; }
        public List<AppointmentStatus> AppointmentStatuses { get; set; }
    }
}