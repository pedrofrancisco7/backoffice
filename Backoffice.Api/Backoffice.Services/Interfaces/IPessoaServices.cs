using System;
using Backoffice.Domain.Entities;

namespace Backoffice.Services.Interfaces;

public interface IPessoaServices : IBaseServices<PessoaEntity>
{
    Task<bool> Exists(string documento);
}

