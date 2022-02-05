using Microsoft.EntityFrameworkCore;
using PaidParking3;

class DatabaseContext : DbContext
{
    public DbSet<Cell> Cells { get; set; }

    public DatabaseContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Parkings.db");
    }
}