using SMS.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Cart Cart { get; set; }

        public string CartId { get; set; }
    }
}
