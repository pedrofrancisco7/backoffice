using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Backoffice.Services.Interfaces;

namespace Backoffice.Services.Services;

public class DepartamentoServices : BaseServices<DepartamentoEntity>, IDepartamentoServices
{
    private readonly IRepositoryBase<DepartamentoEntity> _repositoryBase;
    private readonly IDepartamentoRepository _departamentoRepository;
    public DepartamentoServices(IDepartamentoRepository departamentoRepository,
                                IRepositoryBase<DepartamentoEntity> repositoryBase) : base(repositoryBase)
    {
        _repositoryBase = repositoryBase;
        _departamentoRepository = departamentoRepository;
    }

    public async Task<bool> Exists(string nome)
    {
        return await _departamentoRepository.Exists(nome);
    }
}

