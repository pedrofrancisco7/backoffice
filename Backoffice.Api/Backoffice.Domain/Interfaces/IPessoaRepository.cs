using System;
namespace Backoffice.Domain.Interfaces;

public interface IPessoaRepository
{
    Task<bool> Exists(string documento);
}

