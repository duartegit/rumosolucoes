using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pedido> tbl_pedido { get; set; }
        public DbSet<Cozinha> tbl_cozinha { get; set; }
        public DbSet<Copa> tbl_copa { get; set; }
    }
}
