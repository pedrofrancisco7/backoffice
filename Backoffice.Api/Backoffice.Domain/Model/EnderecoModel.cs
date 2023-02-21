using System;
using Backoffice.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Backoffice.Domain.Model;

public class EnderecoModel
{
    public string? cep { get; set; }
    public string? logradouro { get; set; }
    public string? complemento { get; set; }
    public string? bairro { get; set; }
    public string? localidade { get; set; }
    public string? uf { get; set; }
    public string? ibge { get; set; }
    public string? gia { get; set; }
    public string? ddd { get; set; }
    public string? siafi { get; set; }
    public string? num { get; set; }

    [ForeignKey("IdPessoa")]
    public Guid IdPessoa { get; set; }
    
}

