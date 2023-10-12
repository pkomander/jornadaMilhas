using AutoMapper;
using Domain;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Companhia, CompanhiaDto>().ReverseMap();
            CreateMap<Depoimento, DepoimentoDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Passagem, PassagemDto>().ReverseMap();
            CreateMap<Promocao, PromocaoDto>().ReverseMap();
        }
    }
}
