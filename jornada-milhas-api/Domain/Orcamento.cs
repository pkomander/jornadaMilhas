using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Orcamento
    {
        public int OrcamentoId { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal TaxaEmbarque { get; set; }
        public decimal Total { get; set; }
    }
}
