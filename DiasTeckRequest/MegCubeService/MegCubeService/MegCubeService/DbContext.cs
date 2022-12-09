using DiasService.Entities;
using System.Data.Entity;

namespace MegCubeService
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("server=localhost;database=DownNotifier;Trusted_Connection=true;")
        {

        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserUrls> UserUrls { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
    }
}