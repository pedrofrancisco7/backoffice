using System;
using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Data.Mapping;

public class PessoasMap : IEntityTypeConfiguration<PessoaEntity>
{
    public void Configure(EntityTypeBuilder<PessoaEntity> builder)
    {
        builder.ToTable("Pessoas");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.TipoPessoa)
               .IsRequired()
               .HasMaxLength(8);

        builder.HasIndex(u => u.Documento)
               .IsUnique();

        builder.Property(u => u.Documento)
                .HasMaxLength(14);


        builder.Property(u => u.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Apelido)
               .HasMaxLength(120);

        builder.HasOne(c => c.Endereco)
               .WithOne(c => c.Pessoa)
               .HasForeignKey<EnderecoEntity>(c => c.IdPessoa);

        builder.HasMany(c => c.Departamentos)
               .WithOne(c => c.Responsavel)
               .HasForeignKey(c => c.Id);

        


    }
}

