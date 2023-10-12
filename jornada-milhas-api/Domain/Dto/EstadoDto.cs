using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EstadoDto
    {
        public int? EstadoId { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [MaxLength(20, ErrorMessage = "O {0} do Nome nao pode exceder 20 caracteres")]
        [MinLength(3, ErrorMessage = "O {0} do Nome nao pode ser menor que 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [MaxLength(4, ErrorMessage = "O {0} do Nome nao pode exceder 20 caracteres")]
        [MinLength(2, ErrorMessage = "O {0} do Nome nao pode ser menor que 3 caracteres")]
        public string Sigla { get; set; }
    }
}
