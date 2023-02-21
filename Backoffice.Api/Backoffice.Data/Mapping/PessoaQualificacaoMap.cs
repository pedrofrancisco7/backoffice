using System;
using System.Reflection.Emit;
using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Data.Mapping;

public class PessoaQualificacaoMap : IEntityTypeConfiguration<PessoaQualificacaoEntity>
{
    public void Configure(EntityTypeBuilder<PessoaQualificacaoEntity> builder)
    {
        builder.ToTable("PessoasQualificacoes");

        builder.Ignore(c => c.Id);
        builder.Ignore(c => c.CriadoEm);
        builder.Ignore(c => c.AtualizadoEm);
        builder.Ignore(c => c.Status);


        builder.HasKey(pq => new { pq.IdPessoa, pq.IdQualificacao });

        builder.HasOne(pq => pq.Pessoa)
               .WithMany(q => q.PessoasQualificacoes)
               .HasForeignKey(p => p.IdPessoa);

        builder.HasOne(pq => pq.Qualificacao)
               .WithMany(p => p.PessoasQualificacoesEntity)
               .HasForeignKey(q => q.IdQualificacao);

    }
}

