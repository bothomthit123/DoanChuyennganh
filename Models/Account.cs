using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartTravelAPI.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }  

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }

        // Quan hệ
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<SearchHistory> SearchHistories { get; set; }
    }
}
