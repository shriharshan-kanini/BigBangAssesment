﻿using System.ComponentModel.DataAnnotations;

namespace BigBangAssesment.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; } = string.Empty;
        public int? CustomerNumber { get; set;}

        public Hotel? Hotel { get; set; } 
    }
}