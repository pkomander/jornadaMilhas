using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DepoimentoDto
    {
        public int? DepoimentoId { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [MaxLength(100, ErrorMessage = "O {0} do Nome nao pode exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "O {0} do Nome nao pode ser menor que 3 caracteres")]
        public string Texto { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [MaxLength(15, ErrorMessage = "O {0} do Nome nao pode exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "O {0} do Nome nao pode ser menor que 3 caracteres")]
        public string Autor { get; set; }
        public string Avatar { get; set; }
    }
}
