using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Interface
{
    public interface IEstadoService
    {
        Task<EstadoDto> Add(EstadoDto model);
        Task<List<EstadoDto>> GetAll();
        Task<EstadoDto> GetById(int Id);
        Task<EstadoDto> Update(int Id, EstadoDto model);
        Task<bool> Delete(int Id);
    }
}
