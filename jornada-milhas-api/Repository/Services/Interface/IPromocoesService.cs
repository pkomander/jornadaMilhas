using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Interface
{
    public interface IPromocoesService
    {
        Task<PromocaoDto> Add(PromocaoDto model);
        Task<List<PromocaoDto>> GetAll();
        Task<PromocaoDto> GetById(int Id);
        Task<PromocaoDto> Update(int Id, PromocaoDto model);
        Task<bool> Delete(int Id);
    }
}
