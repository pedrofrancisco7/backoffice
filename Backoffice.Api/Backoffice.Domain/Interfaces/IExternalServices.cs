using System;
using Backoffice.Domain.Entities;

namespace Backoffice.Domain.Interfaces
{
	public interface IExternalServices
	{
		Task<EnderecoEntity?> GetEndereco(string cep);
	}
}

