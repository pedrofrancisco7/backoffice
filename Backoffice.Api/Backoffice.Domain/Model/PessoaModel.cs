using System;
using Backoffice.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Backoffice.Domain.Model;

public class PessoaModel
{
    public PessoaModel()
    {
        Qualificacoes = new List<Guid>();
    }

    [Required]
    [StringLength(8)]
    public string? TipoPessoa { get; set; }

    [Required]
    [StringLength(14)]
    public string? Documento { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }

    [StringLength(120)]
    public string? Apelido { get; set; }

    [ForeignKey("IdDepartamento")]
    public Guid IdDepartamento { get; set; }

    [Required]
    public string? Cep { get; set; }

    [Required]
    public List<Guid>? Qualificacoes { get; set; }

    public EnderecoModel Endereco { get; set; }

}

