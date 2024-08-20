
namespace InvestmentProj.ViewModels
{
    public class RoomVM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public int ReviewCount { get; set; }
        public decimal Rating { get; set; }
        public bool IsAvailable { get; set; } // Add this property
    }

}
