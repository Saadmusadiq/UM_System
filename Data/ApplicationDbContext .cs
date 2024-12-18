using Microsoft.EntityFrameworkCore;
using UM_System.Models;


namespace UM_System.Data
{
    public class DbContextcs
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            public DbSet<Application> Applications { get; set; }
            public DbSet<Page> Pages { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<RolePagePermission> RolePagePermissions { get; set; }
        }

    }
}
