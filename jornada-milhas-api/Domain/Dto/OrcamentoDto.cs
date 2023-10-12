using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class OrcamentoDto
    {
        public int? OrcamentoId { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [MaxLength(20, ErrorMessage = "O {0} do Nome nao pode exceder 20 caracteres")]
        [MinLength(3, ErrorMessage = "O {0} do Nome nao pode ser menor que 3 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public decimal TaxaEmbarque { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public decimal Total { get; set; }
    }
}
