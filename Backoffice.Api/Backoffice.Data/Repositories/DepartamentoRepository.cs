using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Data.Repositories;

public class DepartamentoRepository : RepositoryBase<DepartamentoEntity>, IDepartamentoRepository
{
    private readonly DbSet<DepartamentoEntity> _dataset;

    public DepartamentoRepository(AppDbContext context) : base(context)
    {
        _dataset = context.Set<DepartamentoEntity>();
    }

    public async Task<bool> Exists(string nome)
    {
        try
        {

            return await _dataset.AnyAsync(p => p.Nome.ToLower().Equals(nome.ToLower()));

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }


}



