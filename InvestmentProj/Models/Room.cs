using System;  // For common data types like DateTime, int, etc.
using System.ComponentModel.DataAnnotations;  // For attributes like [Key], [Required], etc.
using System.ComponentModel.DataAnnotations.Schema;  // For attributes like [Table], [ForeignKey], etc.

namespace InvestmentProj.Models  // Replace with your actual namespace
{
    public class Room
    {
        [Key]  // Primary key attribute
        public int RoomId { get; set; }

        [Required]  // Makes the field required (non-nullable)
        [StringLength(100)]  // Limits the length of the string
        public string RoomType { get; set; }

        public string Status { get; set; }

        [Column(TypeName = "decimal(18,2)")]  // Specifies the SQL data type
        public decimal Price { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }
        public string isAvailable { get; set; }
    }
}
