using System;

namespace InvestmentProj.Models
{
    public class BookRoomViewModel
    {
        public string HotelType { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
