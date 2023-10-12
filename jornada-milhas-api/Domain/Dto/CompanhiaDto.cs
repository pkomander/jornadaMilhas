using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CompanhiaDto
    {
        public int? CompanhiaId { get; set; }
        [Required(ErrorMessage = "O Nome e obrigatorio")]
        [MaxLength(50, ErrorMessage = "O tamanho do Nome nao pode exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "O tamanho do Nome nao pode ser menor que 3 caracteres")]
        public int Nome { get; set; }
    }
}
