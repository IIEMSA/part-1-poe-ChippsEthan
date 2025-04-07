namespace CLDV6211POE.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int VenueID { get; set; }
        public Venue? venue { get; set; }

        public int EventID { get; set; }
        public Event? events { get; set; }

        
    }
}
