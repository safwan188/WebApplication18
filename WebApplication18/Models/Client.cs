﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication18.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string? email { get; set; }
        public string firstName { get; set; }
        public string? password { get; set; }
        public string lastName { get; set; }
        public string? phonenumber { get; set; }
        
    }
}
