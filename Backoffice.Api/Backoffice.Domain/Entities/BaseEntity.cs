using System;
using System.ComponentModel.DataAnnotations;

namespace Backoffice.Domain.Entities;

public enum enStatus : short { Deletado = -1, Desativado = 0, Ativo = 1 }

public abstract class BaseEntity
{
    internal BaseEntity()
    {
        CriadoEm = DateTime.UtcNow;
        Status = (int)enStatus.Ativo;        
    }

    [Key]
    public Guid Id { get; set; }

    private DateTime? _criadoEm;

    public DateTime? CriadoEm
    {
        get { return _criadoEm; }
        set { _criadoEm = (value == null ? DateTime.UtcNow : value); }
    }

    public DateTime? AtualizadoEm { get; set; }
    public int Status { get; set; }  

}


