using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Backoffice.Services.Interfaces;

namespace Backoffice.Services.Services;

public class PessoaQualificacaoServices : BaseServices<PessoaQualificacaoEntity>, IPessoaQualificacaoServices
{
    private readonly IRepositoryBase<PessoaQualificacaoEntity> _repositoryBase;
    private readonly IPessoaQualificacaoRepository _pessoaQualificacaoRepository;
    public PessoaQualificacaoServices(IPessoaQualificacaoRepository pessoaQualificacaoRepository,
                                      IRepositoryBase<PessoaQualificacaoEntity> repositoryBase) : base(repositoryBase)
    {
        _repositoryBase = repositoryBase;
        _pessoaQualificacaoRepository = pessoaQualificacaoRepository;
    }

    public async Task InsertPessoaQualificacao(Guid idPessoa, Guid idQualificacao)
    {
        await _pessoaQualificacaoRepository.InsertPessoaQualificacao(idPessoa, idQualificacao);
    }
}

