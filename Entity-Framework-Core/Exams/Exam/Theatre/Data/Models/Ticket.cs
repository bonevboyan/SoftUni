﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.Data.Models
{
    public class Ticket
    {

        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        [Required]
        public Play Play { get; set; }

        [Required]
        public int TheatreId { get; set; }

        [Required]
        public Theatre Theatre { get; set; }

    }
}
