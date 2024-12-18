using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UM_System.Models;

namespace UM_System.Data
{
    public class UM_SystemContext : DbContext
    {
        public UM_SystemContext (DbContextOptions<UM_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<UM_System.Models.Application> Application { get; set; } = default!;
        public DbSet<UM_System.Models.Page> Page { get; set; } = default!;
        public DbSet<UM_System.Models.User> User { get; set; } = default!;
        public DbSet<UM_System.Models.Role> Role { get; set; } = default!;
    }
}
