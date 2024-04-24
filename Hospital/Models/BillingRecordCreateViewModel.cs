using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Models
{
    public class BillingRecordCreateViewModel
    {
        [Required(ErrorMessage = "Please select an appointment")]
        [Display(Name = "Appointment")]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Please select a patient")]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please enter the amount")]
        [Display(Name = "Amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please enter the billing date")]
        [Display(Name = "Billing Date")]
        public DateTime BillingDate { get; set; }

        [MaxLength(200)]
        public string Notes { get; set; }

        public List<SelectListItem> Appointments { get; set; }

       
        public List<SelectListItem> Patients { get; set; } 
    }
}