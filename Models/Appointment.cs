namespace AppointAPI.Models
{
    public class Appointment
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        
    }
}
