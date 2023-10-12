using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Promocao
    {
        [Key]
        [Required]
        public int PromocaoId { get; set; }
        public string Destino { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
    }
}
