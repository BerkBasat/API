using System.ComponentModel.DataAnnotations;

namespace MINAPI.DTOs
{
    public class CommandUpdateDto
    {
        [Required]
        public string? HowTo { get; set; }

        [Required]
        public string? Platform { get; set; }

        [Required]
        public string? CommandLine { get; set; }
    }
}