using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Companhia
    {
        [Key]
        [Required]
        public int CompanhiaId { get; set; }
        public int Nome { get; set; }
    }
}