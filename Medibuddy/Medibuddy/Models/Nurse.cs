﻿namespace Medibuddy.Models
{
    public class Nurse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty ;
        public string Email { get; set; } = string.Empty ;
        public char Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
