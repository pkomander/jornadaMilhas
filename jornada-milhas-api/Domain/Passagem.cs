using Domain.Dto;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Passagem
    {
        public int PassagemId { get; set; }
        public TipoPassagem TipoPassagem { get; set; }
        public decimal PrecoIda { get; set; }
        public decimal PrecoVolta { get; set; }
        public decimal TaxaEmbarque { get; set; }
        public int Conexoes { get; set; }
        public int Duracao { get; set; }
        public int TempoVoo { get; set; }
        public int OrigemId { get; set; }
        public virtual EstadoDto Origem { get; set; }
        public int DestinoId { get; set; }
        public virtual EstadoDto Destino { get; set; }
        public int CompanhiaId { get; set; }
        public virtual CompanhiaDto Companhia { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime? DataVolta { get; set; }
        public int Total { get; set; }
        public int OrcamentoId { get; set; }
        public virtual OrcamentoDto Orcamento { get; set; }
    }
}
