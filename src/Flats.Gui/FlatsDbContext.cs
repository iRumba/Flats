using Flats.Gui.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flats.Gui
{
    public class FlatsDbContext : DbContext
    {
        public FlatsDbContext(DbContextOptions<FlatsDbContext> options) : base(options) 
        {            
            //var res = Database.EnsureCreated();
        }

        public DbSet<Flat> Flats { get; set; }

        public DbSet<Site> Sites { get; set; }

        public DbSet<FlatSite> FlatSites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>().HasKey(x => x.Id);
            modelBuilder.Entity<Flat>().Property(x => x.Id).HasDefaultValueSql("CONVERT(varchar(255), NEWID())");

            modelBuilder.Entity<Site>().HasKey(x => x.Id);
            modelBuilder.Entity<Site>().Property(x => x.Id).HasDefaultValueSql("CONVERT(varchar(255), NEWID())");

            modelBuilder.Entity<FlatSite>().HasKey(x => new { x.FlatId, x.SiteId });
            modelBuilder.Entity<FlatSite>()
                .HasOne(x => x.Flat)
                .WithMany(x => x.FlatSites)
                .HasForeignKey(x => x.FlatId)
                .IsRequired();

            modelBuilder.Entity<FlatSite>()
                .HasOne(x => x.Site)
                .WithMany()
                .HasForeignKey(x => x.SiteId)
                .IsRequired();

            modelBuilder.Entity<FlatSite>()
                .Property(x => x.ForeignKey)
                .IsRequired();
        }
    }
}
