using iBanking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Data
{
    public class iBankContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAcc> BankAccs { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<UserAuth> UserAuths { get; set; }

        public iBankContext(DbContextOptions<iBankContext> options)
            :base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\localThienPhu;Initial Catalog=iBanking;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.cccd)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.email)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.phone);
            modelBuilder.Entity<BankAcc>()
                .HasOne(b=>b.Customer)
                .WithMany(c=>c.BankAccs)
                .HasForeignKey(b=>b.idCus)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BankCard>()
                .HasOne(bC=>bC.BankAccs)
                .WithMany(ba=>ba.BankCards)
                .HasForeignKey(bc=>bc.idAcc)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Loans>()
                .HasOne(l=>l.BankAcc)
                .WithMany(ba=>ba.Loans)
                .HasForeignKey(l=>l.idAcc)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Transactions>()
                .HasOne(t=>t.BankAcc)
                .WithMany(b=>b.Transactions)
                .HasForeignKey(t=>t.idAcc)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserAuth>()
                .HasOne(ua => ua.BankAcc)
                .WithMany(ba => ba.UserAuths)
                .HasForeignKey(ua => ua.idAcc)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

