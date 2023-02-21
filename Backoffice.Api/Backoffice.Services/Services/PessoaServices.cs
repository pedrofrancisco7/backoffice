using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Backoffice.Services.Interfaces;

namespace Backoffice.Services.Services;

public class PessoaServices : BaseServices<PessoaEntity>, IPessoaServices
{
    private readonly IRepositoryBase<PessoaEntity> _repositoryBase;
    private readonly IPessoaRepository _pessoaRepository;
    public PessoaServices(IPessoaRepository pessoaRepository,
                          IRepositoryBase<PessoaEntity> repositoryBase) : base(repositoryBase)
	{
        _repositoryBase = repositoryBase;
        _pessoaRepository = pessoaRepository;
	}

    public Task<bool> Exists(string documento)
    {
        return _pessoaRepository.Exists(documento);
    }
}

