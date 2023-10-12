using Domain;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Interface
{
    public interface IDepoimentoService
    {
        Task<DepoimentoDto> Add(DepoimentoDto model);
        Task<List<DepoimentoDto>> GetAll();
        Task<DepoimentoDto> GetById(int Id);
        Task<DepoimentoDto> Update(int Id, DepoimentoDto model);
        Task<bool> Delete(int Id);
    }
}
