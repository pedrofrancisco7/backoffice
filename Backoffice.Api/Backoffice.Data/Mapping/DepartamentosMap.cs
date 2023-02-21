using System;
using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Data.Mapping;

public class DepartamentosMap : IEntityTypeConfiguration<DepartamentoEntity>
{
    public void Configure(EntityTypeBuilder<DepartamentoEntity> builder)
    {
        builder.ToTable("Departamentos");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Nome)
               .IsUnique();

        builder.Property(u => u.Nome)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasOne(p => p.Responsavel)
               .WithMany(p => p.Departamentos)
               .HasForeignKey(c => c.IdResponsavel);

    }
}
