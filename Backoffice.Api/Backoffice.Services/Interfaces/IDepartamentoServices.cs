using System;
using Backoffice.Domain.Entities;

namespace Backoffice.Services.Interfaces;

public interface IDepartamentoServices : IBaseServices<DepartamentoEntity>
{
    Task<bool> Exists(string nome);
}

