namespace kt7.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string ResourceType { get; set; }
        public string ResourceId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
    }
}
