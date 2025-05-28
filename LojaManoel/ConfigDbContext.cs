using LojaManoel.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaManoel
{

    public class ConfigDbContext : DbContext
    {
        public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options) { }

        DbSet<HistoricoPedidosDb> Historico { get; set; }
    }

}
