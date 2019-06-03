using Microsoft.EntityFrameworkCore;
using SM.CrossCutting.Models.Models;
using System;

namespace SM.Data.Providers.Sql
{
    public class SMContext: DbContext
    {
        public SMContext(DbContextOptions<SMContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Compaign> Compaigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Compaign>().ToTable("Compaign");
        }
    }
}
