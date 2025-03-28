﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iBanking.Data;

#nullable disable

namespace iBanking.Migrations
{
    [DbContext(typeof(iBankContext))]
    partial class iBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("iBanking.Models.BankAcc", b =>
                {
                    b.Property<Guid>("idAcc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("accNum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("currBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("idCus")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("openDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("typeAcc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idAcc");

                    b.HasIndex("idCus");

                    b.ToTable("BankAccs");
                });

            modelBuilder.Entity("iBanking.Models.BankCard", b =>
                {
                    b.Property<Guid>("idCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("expiredCard")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("idAcc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("numberCard")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("statusCard")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("typeCard")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idCard");

                    b.HasIndex("idAcc");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("iBanking.Models.Customer", b =>
                {
                    b.Property<Guid>("idCus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("cccd")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("idCus");

                    b.HasIndex("cccd")
                        .IsUnique();

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("phone");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("iBanking.Models.Loans", b =>
                {
                    b.Property<Guid>("idLoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idAcc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("term")
                        .HasColumnType("int");

                    b.HasKey("idLoan");

                    b.HasIndex("idAcc");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("iBanking.Models.Transactions", b =>
                {
                    b.Property<Guid>("idTransaction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idAcc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("money")
                        .HasColumnType("float");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<string>("typeTrans")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idTransaction");

                    b.HasIndex("idAcc");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("iBanking.Models.UserAuth", b =>
                {
                    b.Property<Guid>("idUserAuth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idAcc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("typeAuth")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idUserAuth");

                    b.HasIndex("idAcc");

                    b.ToTable("UserAuths");
                });

            modelBuilder.Entity("iBanking.Models.BankAcc", b =>
                {
                    b.HasOne("iBanking.Models.Customer", "Customer")
                        .WithMany("BankAccs")
                        .HasForeignKey("idCus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("iBanking.Models.BankCard", b =>
                {
                    b.HasOne("iBanking.Models.BankAcc", "BankAccs")
                        .WithMany("BankCards")
                        .HasForeignKey("idAcc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccs");
                });

            modelBuilder.Entity("iBanking.Models.Loans", b =>
                {
                    b.HasOne("iBanking.Models.BankAcc", "BankAcc")
                        .WithMany("Loans")
                        .HasForeignKey("idAcc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAcc");
                });

            modelBuilder.Entity("iBanking.Models.Transactions", b =>
                {
                    b.HasOne("iBanking.Models.BankAcc", "BankAcc")
                        .WithMany("Transactions")
                        .HasForeignKey("idAcc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAcc");
                });

            modelBuilder.Entity("iBanking.Models.UserAuth", b =>
                {
                    b.HasOne("iBanking.Models.BankAcc", "BankAcc")
                        .WithMany("UserAuths")
                        .HasForeignKey("idAcc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAcc");
                });

            modelBuilder.Entity("iBanking.Models.BankAcc", b =>
                {
                    b.Navigation("BankCards");

                    b.Navigation("Loans");

                    b.Navigation("Transactions");

                    b.Navigation("UserAuths");
                });

            modelBuilder.Entity("iBanking.Models.Customer", b =>
                {
                    b.Navigation("BankAccs");
                });
#pragma warning restore 612, 618
        }
    }
}
