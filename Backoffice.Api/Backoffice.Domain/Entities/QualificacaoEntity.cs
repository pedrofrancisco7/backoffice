using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Backoffice.Domain.Entities;

public class QualificacaoEntity : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }


    [IgnoreDataMember]
    public List<PessoaQualificacaoEntity>? PessoasQualificacoesEntity { get; set; }
}

