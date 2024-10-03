using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BOTCDatabase.Models;

namespace BOTCDatabase.Data
{
    public class BludContext : DbContext
    {
        public BludContext (DbContextOptions<BludContext> options)
            : base(options)
        {
        }

        public DbSet<BOTCDatabase.Models.Role> Role { get; set; } = default!;
    }
}
