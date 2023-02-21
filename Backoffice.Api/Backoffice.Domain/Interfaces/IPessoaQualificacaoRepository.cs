using System;
using Backoffice.Domain.Entities;

namespace Backoffice.Domain.Interfaces
{
	public interface IPessoaQualificacaoRepository : IRepositoryBase<PessoaQualificacaoEntity>
    {
        Task InsertPessoaQualificacao(Guid idPessoa, Guid idQualificacao);
    }
}

