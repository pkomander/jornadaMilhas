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
    public class PromocaoRepository : IPromocoesService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;
        public PromocaoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PromocaoDto> Add(PromocaoDto model)
        {
            try
            {
                var promocao = _mapper.Map<Promocao>(model);
                _context.Promocoes.Add(promocao);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(promocao.PromocaoId);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PromocaoDto>> GetAll()
        {
            try
            {
                var promocao = await _context.Promocoes.ToListAsync();
                var listaMapper = _mapper.Map<List<PromocaoDto>>(promocao);

                return listaMapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PromocaoDto> GetById(int Id)
        {
            try
            {
                var promocao = await _context.Promocoes.FirstOrDefaultAsync(p => p.PromocaoId == Id);

                if (promocao == null)
                {
                    return null;
                }

                var promocaoMapper = _mapper.Map<PromocaoDto>(promocao);
                return promocaoMapper;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PromocaoDto> Update(int Id, PromocaoDto model)
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
                var recuperaPromocao = await _context.Promocoes.FirstOrDefaultAsync(p => p.PromocaoId == Id);

                if (recuperaPromocao == null)
                {
                    throw new Exception("Servico para delete nao encontrado.");
                }

                _context.Promocoes.Remove(recuperaPromocao);
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
