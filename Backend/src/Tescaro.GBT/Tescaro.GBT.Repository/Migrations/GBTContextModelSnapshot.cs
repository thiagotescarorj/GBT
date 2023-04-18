﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tescaro.GBT.Repository;

#nullable disable

namespace Tescaro.GBT.Repository.Migrations
{
    [DbContext(typeof(GBTContext))]
    partial class GBTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.BancoDados", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("BancoDados");
                });

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.Chamado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BancoDadosId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("DNSId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DataEnvioHomologacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRecebimento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScriptText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BancoDadosId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DNSId");

                    b.ToTable("Chamado");
                });

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.DNS", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtividade")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("DNS");
                });

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.BancoDados", b =>
                {
                    b.HasOne("Tescaro.GBT.Domain.Models.Cliente", "Cliente")
                        .WithMany("BancosDados")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.Chamado", b =>
                {
                    b.HasOne("Tescaro.GBT.Domain.Models.BancoDados", "BancoDados")
                        .WithMany()
                        .HasForeignKey("BancoDadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tescaro.GBT.Domain.Models.Cliente", "Cliente")
                        .WithMany("Chamados")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tescaro.GBT.Domain.Models.DNS", "DNS")
                        .WithMany()
                        .HasForeignKey("DNSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BancoDados");

                    b.Navigation("Cliente");

                    b.Navigation("DNS");
                });

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.DNS", b =>
                {
                    b.HasOne("Tescaro.GBT.Domain.Models.Cliente", "Cliente")
                        .WithMany("DNSs")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Tescaro.GBT.Domain.Models.Cliente", b =>
                {
                    b.Navigation("BancosDados");

                    b.Navigation("Chamados");

                    b.Navigation("DNSs");
                });
#pragma warning restore 612, 618
        }
    }
}
