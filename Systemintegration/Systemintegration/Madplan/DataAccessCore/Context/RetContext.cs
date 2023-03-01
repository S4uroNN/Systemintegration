using DataAccessCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Context
{
    internal class RetContext : DbContext
    {
        public RetContext()
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database Created");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-U2JGUM3J\\SQLEXPRESS;Initial Catalog=Madplan;Integrated Security=SSPI; TrustServerCertificate=true");
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ret>().HasData(new Ret[] {
                new Ret{Id=-1,Navn="Kyllingefrikadeller"},
                new Ret{Id=2,Navn="Spaghetti Kødsovs"},
                new Ret{Id=3,Navn="Mørbrad"}
            });
        }

        public DbSet<Ret> Rets { get; set; }

    }
}
