using Microsoft.EntityFrameworkCore;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ConsumidorModel> Consumidores { get; set; }
        public DbSet<InfoConsumidorModel> InfosConsumidores { get; set; }





    }
}
