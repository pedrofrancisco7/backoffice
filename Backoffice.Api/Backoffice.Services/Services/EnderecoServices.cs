using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Backoffice.Services.Interfaces;

namespace Backoffice.Services.Services;

public class EnderecoServices : BaseServices<EnderecoEntity>, IEnderecoServices
{
    private readonly IRepositoryBase<EnderecoEntity> _repositoryBase;
    public EnderecoServices(IRepositoryBase<EnderecoEntity> repositoryBase) : base(repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }
}

