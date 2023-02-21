using System;
using Backoffice.Domain.Interfaces;

namespace Backoffice.Services.Services
{
	public class BaseServices<T> : IBaseServices<T> where T : class
	{
        private IRepositoryBase<T> _repositoryBase;
        public BaseServices(IRepositoryBase<T> repositoryBase)
		{
            _repositoryBase = repositoryBase;
		}

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repositoryBase.DeleteAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            return await _repositoryBase.InsertAsync(entity);
        }

        public async Task<T?> SelectAsync(Guid id)
        {
            return await _repositoryBase.SelectAsync(id);
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _repositoryBase.SelectAsync();
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            return await _repositoryBase.UpdateAsync(entity);
        }
    }
}

