using System.ComponentModel.DataAnnotations;

namespace MINAPI.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? HowTo { get; set; }

        [Required]
        public string? Platform { get; set; }

        [Required]
        public string? CommandLine { get; set; }
    }
}