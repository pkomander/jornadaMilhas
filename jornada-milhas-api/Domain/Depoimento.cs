using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Depoimento
    {
        [Key]
        [Required]
        public int DepoimentoId { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }
        public string Avatar { get; set; }
    }
}
