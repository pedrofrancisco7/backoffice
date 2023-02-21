using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Backoffice.Services.Interfaces;

namespace Backoffice.Services.Services;

public class QualificacaoServices : BaseServices<QualificacaoEntity>, IQualificacaoServices
{
    private readonly IRepositoryBase<QualificacaoEntity> _repositoryBase;
    public QualificacaoServices(IRepositoryBase<QualificacaoEntity> repositoryBase) : base(repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }
}

