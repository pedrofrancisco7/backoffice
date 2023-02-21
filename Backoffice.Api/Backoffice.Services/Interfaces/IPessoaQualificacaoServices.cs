using System;
using Backoffice.Domain.Entities;

namespace Backoffice.Services.Interfaces;

public interface IPessoaQualificacaoServices : IBaseServices<PessoaQualificacaoEntity>
{
    Task InsertPessoaQualificacao(Guid idPessoa, Guid idQualificacao);
}

