using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Interface
{
    public interface IPassagemService
    {
        Task<PassagemDto> Add(PassagemDto model);
        Task<List<PassagemDto>> GetAll();
        Task<PassagemDto> GetById(int Id);
        Task<PassagemDto> Update(int Id, PassagemDto model);
        Task<bool> Delete(int Id);
    }
}
