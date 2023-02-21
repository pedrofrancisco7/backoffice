using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Backoffice.Domain.Entities;

public class EnderecoEntity : BaseEntity
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

    public string? erro { get; set; }

    [ForeignKey("IdPessoa")]
    public Guid IdPessoa { get; set; }

    [IgnoreDataMember]
    public virtual PessoaEntity? Pessoa { get; set; }
}

