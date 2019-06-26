
using System;
using System.ComponentModel.DataAnnotations;

namespace PocInkDataLayer.Models
{
    public class InkDrawing
    {
        [Key]
        public Guid DrawingId { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string DrawingName { get; set; }

    }
}
