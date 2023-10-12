using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Estado
    {
        [Key]
        [Required]
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
