using Microsoft.EntityFrameworkCore;
using VetApi.Models;

namespace VetApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<DonoModel> Donos { get; set; }
        public DbSet<VeterinarioModel> Veterinarios { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }

    }
}
