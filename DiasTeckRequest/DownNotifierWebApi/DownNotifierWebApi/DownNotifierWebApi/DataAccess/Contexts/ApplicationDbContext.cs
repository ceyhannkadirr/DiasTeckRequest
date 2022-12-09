using DownNotifierWebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DownNotifierWebApi.DataAccess.Contexts
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserUrls> UserUrls { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
    }
}