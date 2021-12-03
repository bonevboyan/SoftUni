using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor
{
    internal class ImportGameDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public string Genre { get; set; }

        public Purchase[] Purchases { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}