using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        [MaxLength(11, ErrorMessage = "O {0} do Nome nao pode exceder 11 caracteres")]
        [MinLength(11, ErrorMessage = "O {0} do Nome nao pode ser menor que 3 caracteres")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O {0} e obrigatorio")]
        public EstadoDto Estado { get; set; }
    }
}
