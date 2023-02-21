﻿// <auto-generated />
using System;
using Backoffice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backoffice.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230221172950_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backoffice.Domain.Entities.DepartamentoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdResponsavel")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdResponsavel");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Departamentos", (string)null);
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.EnderecoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ddd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("erro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ibge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("localidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("siafi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.PessoaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<Guid>("IdEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .IsUnique();

                    b.ToTable("Pessoas", (string)null);
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.PessoaQualificacaoEntity", b =>
                {
                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdQualificacao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdPessoa", "IdQualificacao");

                    b.HasIndex("IdQualificacao");

                    b.ToTable("PessoasQualificacoes", (string)null);
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.QualificacaoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Qualificacoes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("044013c5-3dc4-403d-ac4e-a78dd0284356"),
                            CriadoEm = new DateTime(2023, 2, 21, 14, 29, 50, 534, DateTimeKind.Local).AddTicks(5030),
                            Nome = "Cliente",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("c3e1ac1e-c260-438f-b800-3d6bfa3cd349"),
                            CriadoEm = new DateTime(2023, 2, 21, 14, 29, 50, 534, DateTimeKind.Local).AddTicks(5090),
                            Nome = "Fornecedor",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("3f3b7b6a-d2f0-416f-b61c-c394fd8710be"),
                            CriadoEm = new DateTime(2023, 2, 21, 14, 29, 50, 534, DateTimeKind.Local).AddTicks(5100),
                            Nome = "Colaborador",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.DepartamentoEntity", b =>
                {
                    b.HasOne("Backoffice.Domain.Entities.PessoaEntity", "Responsavel")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdResponsavel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.EnderecoEntity", b =>
                {
                    b.HasOne("Backoffice.Domain.Entities.PessoaEntity", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("Backoffice.Domain.Entities.EnderecoEntity", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.PessoaQualificacaoEntity", b =>
                {
                    b.HasOne("Backoffice.Domain.Entities.PessoaEntity", "Pessoa")
                        .WithMany("PessoasQualificacoes")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backoffice.Domain.Entities.QualificacaoEntity", "Qualificacao")
                        .WithMany("PessoasQualificacoesEntity")
                        .HasForeignKey("IdQualificacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Qualificacao");
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.PessoaEntity", b =>
                {
                    b.Navigation("Departamentos");

                    b.Navigation("Endereco");

                    b.Navigation("PessoasQualificacoes");
                });

            modelBuilder.Entity("Backoffice.Domain.Entities.QualificacaoEntity", b =>
                {
                    b.Navigation("PessoasQualificacoesEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
