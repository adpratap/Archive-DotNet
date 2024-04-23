using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Archive.Models.Domain
{
    public class ArchiveModel
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Body { get; set; }
        public DateTime DateAndTime { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
