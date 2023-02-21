using System;
using Backoffice.Domain.Entities;

namespace Backoffice.Domain.Interfaces;

public interface IDepartamentoRepository : IRepositoryBase<DepartamentoEntity>
{
    Task<bool> Exists(string nome);
}

