using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Data.Repositories;

public class PessoaQualificacaoRepository : RepositoryBase<PessoaQualificacaoEntity>, IPessoaQualificacaoRepository
{
    private readonly DbSet<PessoaQualificacaoEntity> _dataset;

    public PessoaQualificacaoRepository(AppDbContext context) : base(context)
    {
        _dataset = context.Set<PessoaQualificacaoEntity>();
    }

    public async Task InsertPessoaQualificacao(Guid idPessoa, Guid idQualificacao)
    {
        try
        {
            var pesQual = new PessoaQualificacaoEntity
            {
                IdPessoa = idPessoa,
                IdQualificacao = idQualificacao
            };

            _dataset.Add(pesQual);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }
}

