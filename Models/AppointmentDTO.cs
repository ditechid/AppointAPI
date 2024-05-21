namespace AppointAPI.Models
{
    public class AppointmentDTO
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
    }
}
