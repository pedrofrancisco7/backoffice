using System;
using System.ComponentModel.DataAnnotations;

namespace Backoffice.Domain.Model;

public class DepartamentoModel
{
	[Required]
	public Guid IdResponsavel { get; set; }

	[Required]
	public string? Nome { get; set; }
}

