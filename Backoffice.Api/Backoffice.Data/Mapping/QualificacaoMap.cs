using System;
using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Data.Mapping;

public class QualificacaoMap : IEntityTypeConfiguration<QualificacaoEntity>
{
    public void Configure(EntityTypeBuilder<QualificacaoEntity> builder)
    {
        builder.ToTable("Qualificacoes");

        builder.HasKey(u => u.Id);

        builder.HasIndex(c => c.Nome)
               .IsUnique();

        builder.Property(c => c.Nome)
               .HasMaxLength(50)
               .IsRequired();
    }
}

