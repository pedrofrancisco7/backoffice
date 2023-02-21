using System;
using Backoffice.Data.Mapping;
using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Data;

public class AppDbContext : DbContext
{
    public DbSet<PessoaEntity> Pessoas { get; set; }
    public DbSet<PessoaQualificacaoEntity> PessoasQualificacoes { get; set; }
    public DbSet<DepartamentoEntity> Departamentos { get; set; }
    public DbSet<EnderecoEntity> Endereco { get; set; }
    public DbSet<QualificacaoEntity> Qualificacoes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PessoaEntity>(new PessoasMap().Configure);
        modelBuilder.Entity<PessoaQualificacaoEntity>(new PessoaQualificacaoMap().Configure);
        modelBuilder.Entity<DepartamentoEntity>(new DepartamentosMap().Configure);
        modelBuilder.Entity<EnderecoEntity>(new EnderecoMap().Configure);
        modelBuilder.Entity<QualificacaoEntity>(new QualificacaoMap().Configure);

        InsertDefaultData(modelBuilder);

    }

    public static void InsertDefaultData(ModelBuilder modelBuilder)
    {        
        modelBuilder.Entity<QualificacaoEntity>().HasData(

            new QualificacaoEntity
            {
               Id = Guid.NewGuid(),
               CriadoEm = DateTime.Now,
               Nome = "Cliente",
               Status = 1
            },
            new QualificacaoEntity
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Now,
                Nome = "Fornecedor",
                Status = 1
            }, new QualificacaoEntity
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Now,
                Nome = "Colaborador",
                Status = 1
            });
    }
}

