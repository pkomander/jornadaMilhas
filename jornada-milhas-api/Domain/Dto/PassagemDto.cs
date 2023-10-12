using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PassagemDto
    {
        public int? PassagemId { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public TipoPassagem TipoPassagem { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public decimal PrecoIda { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public decimal PrecoVolta { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public decimal TaxaEmbarque { get; set; }
        public int Conexoes { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [Range(20, 20000, ErrorMessage = "A Duracao do filme e obrigatorio")]
        public int Duracao { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [Range(20, 20000, ErrorMessage = "A Duracao do filme e obrigatorio")]
        public int TempoVoo { get; set; }
        public EstadoDto Origem { get; set; }
        public EstadoDto Destino { get; set; }
        public CompanhiaDto Companhia { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime? DataVolta { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public int Total { get; set; }
        public OrcamentoDto Orcamento { get; set; }
    }
}
