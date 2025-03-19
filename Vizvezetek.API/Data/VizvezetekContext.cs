using Microsoft.EntityFrameworkCore;
using Vizvezetek.API.Models;

namespace Vizvezetek.API.Data
{
    public class VizvezetekContext : DbContext
    {
        public VizvezetekContext(DbContextOptions<VizvezetekContext> options)
            : base(options)
        {

        }

        // táblák
        public DbSet<Munkalap> Munkalapok { get; set; }
        public DbSet<Hely> Helyek { get; set; }
        public DbSet<Szerelo> Szerelok { get; set; }

    }


}