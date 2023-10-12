using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PromocaoDto
    {
        public int PromocaoId { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public string Destino { get; set; }
        public string Imagem { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public decimal Preco { get; set; }
    }
}
