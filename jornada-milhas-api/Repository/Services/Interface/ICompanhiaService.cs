using Domain;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Interface
{
    public interface ICompanhiaService
    {
        Task<CompanhiaDto> Add(CompanhiaDto model);
        Task<List<CompanhiaDto>> GetAll();
        Task<CompanhiaDto> GetById(int Id);
        Task<CompanhiaDto> Update(int Id, CompanhiaDto model);
        Task<bool> Delete(int Id);
    }
}
