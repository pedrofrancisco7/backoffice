using System;
using AutoMapper;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Model;

namespace Backoffice.IoC.DependencyInjection;

public class ModelToEntityProfile : Profile
{
    public ModelToEntityProfile()
    {
        CreateMap<PessoaEntity, PessoaModel>().ReverseMap();
        CreateMap<EnderecoEntity, EnderecoModel>().ReverseMap();
        CreateMap<DepartamentoEntity, DepartamentoModel>().ReverseMap();
    }
}

