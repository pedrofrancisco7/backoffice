using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Backoffice.Domain.Entities;

public class DepartamentoEntity : BaseEntity
{
	[Required]
	[StringLength(50)]
	public string? Nome { get; set; }

    [ForeignKey("IdResponsavel")]
    public Guid IdResponsavel { get; set; }


    [IgnoreDataMember]
    [ForeignKey("IdResponsavel")]
    public virtual PessoaEntity? Responsavel { get; set; }
	
}

