using System;
using System.Collections.Generic;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using ExternalServices.Requests;
using Newtonsoft.Json;

namespace ExternalServices.Services;

public class ExternalServices : IExternalServices
{
    public async Task<EnderecoEntity?> GetEndereco(string cep)
    {
        try
        {
            var response = await new HttpRequest().GetCep(cep);

            var result = await response.Content.ReadAsStringAsync();


            var endereco = JsonConvert.DeserializeObject<EnderecoEntity>(result) ?? new EnderecoEntity();
            return endereco;

        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message, ex);
            return new EnderecoEntity { erro = "true" };
        }
    }
}

