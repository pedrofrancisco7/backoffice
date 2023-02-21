using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Data.Repositories;

public class PessoaRepository : RepositoryBase<PessoaEntity>, IPessoaRepository
{
    private readonly DbSet<PessoaEntity> _dataset;

    public PessoaRepository(AppDbContext context) : base(context)
    {
        _dataset = context.Set<PessoaEntity>();
    }

    public async Task<bool> Exists(string documento)
    {
        try
        {
            return await _dataset.AnyAsync(p => p.Documento.ToLower().Equals(documento.ToLower()));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }


}





