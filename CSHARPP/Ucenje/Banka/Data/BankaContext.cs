using Banka.Models;
using Microsoft.EntityFrameworkCore;

namespace Banka.Data

{
    public class BankaContext : DbContext
    {
        public BankaContext(DbContextOptions<BankaContext> options)
            : base(options)
        {

        }
        public DbSet<Kredit> Krediti { get; set; }
        public DbSet<Posudba> Posudbe { get; set; }
        public DbSet<Komitent> Komitenti { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Posudba>().HasOne(g => g.Kredit);
            //modelBuilder.Entity<Posudba>().HasOne(g => g.Komitent);


        }
    }
}