using System;
using System.ComponentModel.DataAnnotations;

namespace PocInkDataLayer.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
      
    }
}
