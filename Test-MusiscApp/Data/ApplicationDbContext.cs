using Microsoft.EntityFrameworkCore;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Client { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetail { get; set; }
    }
}
