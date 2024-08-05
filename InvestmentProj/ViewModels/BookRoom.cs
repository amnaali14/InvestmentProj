using System;

namespace YourNamespace.Models
{
    public class BookRoomViewModel
    {
        public string HotelType { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
