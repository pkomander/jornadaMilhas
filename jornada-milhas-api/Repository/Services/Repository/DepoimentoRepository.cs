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
    public class DepoimentoRepository : IDepoimentoService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;
        public DepoimentoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepoimentoDto> Add(DepoimentoDto model)
        {
            try
            {
                var depoimento = _mapper.Map<Depoimento>(model);
                _context.Depoimentos.Add(depoimento);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(depoimento.DepoimentoId);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DepoimentoDto>> GetAll()
        {
            try
            {
                var depoimentos = await _context.Depoimentos.ToListAsync();
                var listaMapper = _mapper.Map<List<DepoimentoDto>>(depoimentos);

                return listaMapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DepoimentoDto> GetById(int Id)
        {
            try
            {
                var depoimento = await _context.Depoimentos.FirstOrDefaultAsync(p => p.DepoimentoId == Id);

                if (depoimento == null)
                {
                    return null;
                }

                var depoimentoMapper = _mapper.Map<DepoimentoDto>(depoimento);
                return depoimentoMapper;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DepoimentoDto> Update(int Id, DepoimentoDto model)
        {
            try
            {
                var recuperaDepoimento = await _context.Depoimentos.FirstOrDefaultAsync(p => p.DepoimentoId == Id);
                var depoimentoMapper = _mapper.Map(model, recuperaDepoimento);
                depoimentoMapper.DepoimentoId = Id;

                _context.Depoimentos.Update(depoimentoMapper);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(depoimentoMapper.DepoimentoId);
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
                var recuperDepoimento = await _context.Depoimentos.FirstOrDefaultAsync(p => p.DepoimentoId == Id);

                if (recuperDepoimento == null)
                {
                    throw new Exception("Servico para delete nao encontrado.");
                }

                _context.Depoimentos.Remove(recuperDepoimento);
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
