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
    public class PassagemRepository : IPassagemService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;
        public PassagemRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PassagemDto> Add(PassagemDto model)
        {
            try
            {
                var passagem = _mapper.Map<Passagem>(model);
                _context.Passagens.Add(passagem);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(passagem.PassagemId);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PassagemDto>> GetAll()
        {
            try
            {
                var passagens = await _context.Passagens
                    .Include(i => i.Companhia)
                    .Include(i => i.Origem)
                    .Include(i => i.Destino)
                    .Include(i => i.Orcamento)
                    .Include(i => i.Companhia).ToListAsync();

                var listaMapper = _mapper.Map<List<PassagemDto>>(passagens);

                return listaMapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PassagemDto> GetById(int Id)
        {
            try
            {
                var passagem = await _context.Passagens
                    .Include(i => i.Companhia)
                    .Include(i => i.Origem)
                    .Include(i => i.Destino)
                    .Include(i => i.Orcamento)
                    .Include(i => i.Companhia).FirstOrDefaultAsync(p => p.PassagemId == Id);

                if (passagem == null)
                {
                    return null;
                }

                var passagemMapper = _mapper.Map<PassagemDto>(passagem);
                return passagemMapper;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PassagemDto> Update(int Id, PassagemDto model)
        {
            try
            {
                var recuperaPassagem = await _context.Passagens
                    .Include(i => i.Companhia)
                    .Include(i => i.Origem)
                    .Include(i => i.Destino)
                    .Include(i => i.Orcamento)
                    .Include(i => i.Companhia).FirstOrDefaultAsync(p => p.PassagemId == Id);

                var passagemMapper = _mapper.Map(model, recuperaPassagem);
                passagemMapper.PassagemId = Id;

                _context.Passagens.Update(passagemMapper);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(passagemMapper.PassagemId);
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
                var recuperaPassagem = await _context.Passagens.FirstOrDefaultAsync(p => p.PassagemId == Id);

                if (recuperaPassagem == null)
                {
                    throw new Exception("Servico para delete nao encontrado.");
                }

                _context.Passagens.Remove(recuperaPassagem);
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
