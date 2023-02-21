using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Backoffice.Domain.Entities;

public class PessoaEntity : BaseEntity
{

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

    [IgnoreDataMember]
    public List<PessoaQualificacaoEntity>? PessoasQualificacoes { get; set; }

    [IgnoreDataMember]
    public virtual List<DepartamentoEntity>? Departamentos { get; set; }

    [ForeignKey("IdEndereco")]
    public Guid IdEndereco { get; set; }

    [IgnoreDataMember]
    public virtual EnderecoEntity? Endereco { get; set; }
    
}
