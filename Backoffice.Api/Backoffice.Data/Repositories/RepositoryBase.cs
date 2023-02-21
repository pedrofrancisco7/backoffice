using System;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Data.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    private DbSet<T> _dataset;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
        _dataset = _context.Set<T>();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (result == null)
                return false;

            _dataset.Remove(result);

            await _context.SaveChangesAsync();

            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        try
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<T> InsertAsync(T entity)
    {
        try
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            entity.CriadoEm = DateTime.UtcNow;
            entity.Status = 1;

            _dataset.Add(entity);

            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        return entity;
    }

    public async Task<T?> SelectAsync(Guid id)
    {
        try
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<IEnumerable<T>> SelectAsync()
    {
        try
        {
            return await _dataset.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<T?> UpdateAsync(T entity)
    {
        try
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));

            if (result == null)
                return null;

            entity.CriadoEm = result.CriadoEm;
            entity.AtualizadoEm = DateTime.UtcNow;

            _context.Entry(result).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message, ex);
        }

        return entity;
    }
}

