using System.Data.Common;
using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class FidelityTrackerDbContext : DbContext
{
    public FidelityTrackerDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<DbPerson> People { get; set; }
    public DbSet<DbGift> Gifts { get; set; }
    public DbSet<DbAcquisition> Acquisitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbPerson>(entity =>
        {
            entity.ToTable("people");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.IdSponsor).HasColumnName("id_sponsor");
        });
        
        modelBuilder.Entity<DbGift>(entity =>
        {
            entity.ToTable("gifts");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<DbAcquisition>(entity =>
        {
            entity.ToTable("acquisitions");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.IdSponsor).HasColumnName("id_sponsor");
            entity.Property(e => e.IdGift).HasColumnName("id_gift");
        });
    }
}