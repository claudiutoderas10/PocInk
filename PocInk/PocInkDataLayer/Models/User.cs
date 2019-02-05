using System;
using System.ComponentModel.DataAnnotations;

namespace PocInkDataLayer.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
