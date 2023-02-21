using System;
using Backoffice.Domain.Entities;

namespace Backoffice.Domain.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<T> InsertAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<T?> SelectAsync(Guid id);
    Task<IEnumerable<T>> SelectAsync();
    Task<bool> ExistsAsync(Guid id);
}

