using Microsoft.EntityFrameworkCore;
using Veiculo.Veiculos;

namespace Unirota.Veiculos.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Veiculos> Veiculos{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //colocar o local da rota 
    {
        optionsBuilder.UseSqlite(optionsBuilder.UseSqlServer("Server=DESKTOP-15CIMC2\\localhost; Initial Catalog=Veiculo; Trusted_Connection=True;TrustServerCertificate=True");

        base.OnConfiguring(optionsBuilder);
    }
}
