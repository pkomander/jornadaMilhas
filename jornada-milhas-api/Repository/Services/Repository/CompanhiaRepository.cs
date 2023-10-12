using AutoMapper;
using Domain;
using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Repository.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Repository
{
    public class CompanhiaRepository : ICompanhiaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public CompanhiaRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompanhiaDto> Add(CompanhiaDto model)
        {
            try
            {
                var companhia = _mapper.Map<Companhia>(model);
                _context.Companhias.Add(companhia);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(companhia.CompanhiaId);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CompanhiaDto>> GetAll()
        {
            try
            {
                var companhias = await _context.Companhias.ToListAsync();
                var listaMapper = _mapper.Map<List<CompanhiaDto>>(companhias);

                return listaMapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanhiaDto> GetById(int Id)
        {
            try
            {
                var companhia = await _context.Companhias.FirstOrDefaultAsync(p => p.CompanhiaId == Id);

                if (companhia == null)
                {
                    return null;
                }

                var placaMapper = _mapper.Map<CompanhiaDto>(companhia);
                return placaMapper;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanhiaDto> Update(int Id, CompanhiaDto model)
        {
            try
            {
                var recuperaCompanhia = await _context.Companhias.FirstOrDefaultAsync(p => p.CompanhiaId == Id);
                var companhiaMapper = _mapper.Map(model, recuperaCompanhia);
                companhiaMapper.CompanhiaId = Id;

                _context.Companhias.Update(companhiaMapper);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetById(companhiaMapper.CompanhiaId);
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
                var recuperaCompanhia = await _context.Companhias.FirstOrDefaultAsync(p => p.CompanhiaId == Id);

                if (recuperaCompanhia == null)
                {
                    throw new Exception("Servico para delete nao encontrado.");
                }

                _context.Companhias.Remove(recuperaCompanhia);
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
