using System;
namespace Backoffice.Services;

public interface IBaseServices<T> where T : class
{
    Task<T> InsertAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<T?> SelectAsync(Guid id);
    Task<IEnumerable<T>> SelectAsync();
}

