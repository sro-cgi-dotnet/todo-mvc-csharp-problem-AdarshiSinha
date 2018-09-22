using Microsoft.EntityFrameworkCore;
using System;
namespace helloworld.Models
{
    public class efmodel : DbContext
    {
        public DbSet<Notes> notes { get; set; }
        public DbSet<Checklist> checklist{get; set;}
        public DbSet<Label> labels{get; set;}

      public efmodel(DbContextOptions<efmodel> options): base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Filename=./notes5.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Notes>().HasMany(n => n.checklist).WithOne().HasForeignKey(c => c.id);
            modelBuilder.Entity<Notes>().HasOne(n=>n.label).WithMany().HasForeignKey(l=> l.id);
        } 
    }
}