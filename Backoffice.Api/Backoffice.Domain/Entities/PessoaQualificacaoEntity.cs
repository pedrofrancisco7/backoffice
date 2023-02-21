using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backoffice.Domain.Entities;

public class PessoaQualificacaoEntity : BaseEntity
{	
	public Guid IdPessoa { get; set; }
	public virtual PessoaEntity? Pessoa { get; set; }
	
    public Guid IdQualificacao { get; set; }
	public virtual QualificacaoEntity? Qualificacao { get; set; }

}

