namespace Hospital.Models
{
    public class BillingRecordViewModel
    {
        public int BillingRecordId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillingDate { get; set; }
        public string Notes { get; set; }
    }
}