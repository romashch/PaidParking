using Microsoft.EntityFrameworkCore;
using PaidParking3;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

public class DatabaseContext : DbContext
{
    public DbSet<Cell> Cells { get; set; }

    public DatabaseContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Parkings.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cell>().HasCheckConstraint("ParkingName", "LENGTH(ParkingName) > 0");
    } 
}