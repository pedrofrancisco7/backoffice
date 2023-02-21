using System;
using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Data.Mapping;

public class EnderecoMap : IEntityTypeConfiguration<EnderecoEntity>
{
    public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
    {
        builder.ToTable("Endereco");

        builder.HasKey(u => u.Id);

        builder.Property("cep");
        builder.Property("logradouro");
        builder.Property("complemento");
        builder.Property("bairro");
        builder.Property("localidade");
        builder.Property("uf");
        builder.Property("ibge");
        builder.Property("gia");
        builder.Property("ddd");
        builder.Property("siafi");

        //builder.HasOne(c => c.Pessoa)
        //       .WithOne(c => c.Endereco)
        //       .HasForeignKey<PessoaEntity>(c => c.IdEndereco);
    }
}

