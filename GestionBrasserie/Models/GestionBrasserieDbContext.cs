using Microsoft.EntityFrameworkCore;

namespace GestionBrasserie.Models;

public class GestionBrasserieDbContext : DbContext
{
    public GestionBrasserieDbContext(DbContextOptions<GestionBrasserieDbContext> options): base(options) {}
    
    public DbSet<Brasserie> Brasseries {get; set;  }
    public DbSet<Biere> Bieres { get; set; }
    public DbSet<Grossiste> Grossistes { get; set; }
    public DbSet<StockGrossiste> StockGrossistes { get; set; }
    public DbSet<Vente> Ventes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StockGrossiste>().HasKey(e => new { stockId = e.StockId, IDGr = e.IdGr });
        modelBuilder.Entity<Vente>().HasKey(et => new { et.Idvente, et.IdGr, et.BiereId});
    }
}