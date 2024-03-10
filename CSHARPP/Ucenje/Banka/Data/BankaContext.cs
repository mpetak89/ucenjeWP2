using Banka.Models;
using Microsoft.EntityFrameworkCore;

namespace Banka.Data
{
    public class BankaContext:DbContext
    {
        public BankaContext(DbContextOptions<BankaContext> options)
            :base(options)
        {

        }
        public DbSet<Kredit>Krediti { get; set; }
    }
}
