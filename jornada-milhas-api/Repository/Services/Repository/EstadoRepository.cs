using AutoMapper;
using Domain;
using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Repository.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Repository
{
    public class EstadoRepository : IEstadoService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;
        public EstadoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EstadoDto> Add(EstadoDto model)
        {
            try
            {
                var estado = _mapper.Map<Estado>(model);
                _context.Estados.Add(estado);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(estado.EstadoId);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EstadoDto>> GetAll()
        {
            try
            {
                var companhias = await _context.Estados.ToListAsync();
                var listaMapper = _mapper.Map<List<EstadoDto>>(companhias);

                return listaMapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstadoDto> GetById(int Id)
        {
            try
            {
                var estado = await _context.Estados.FirstOrDefaultAsync(p => p.EstadoId == Id);

                if (estado == null)
                {
                    return null;
                }

                var estadoMapper = _mapper.Map<EstadoDto>(estado);
                return estadoMapper;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstadoDto> Update(int Id, EstadoDto model)
        {
            try
            {
                var recuperaEstado = await _context.Estados.FirstOrDefaultAsync(p => p.EstadoId == Id);
                var estadoMapper = _mapper.Map(model, recuperaEstado);
                estadoMapper.EstadoId = Id;

                _context.Estados.Update(estadoMapper);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(estadoMapper.EstadoId);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var recuperaEstado = await _context.Estados.FirstOrDefaultAsync(p => p.EstadoId == Id);

                if (recuperaEstado == null)
                {
                    throw new Exception("Servico para delete nao encontrado.");
                }

                _context.Estados.Remove(recuperaEstado);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
