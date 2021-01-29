using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AOTBackend.Models;

namespace AOTBackend.Data
{
    public class AOTBackendContext : DbContext
    {
        public AOTBackendContext (DbContextOptions<AOTBackendContext> options)
            : base(options)
        {
        }

        public DbSet<AOTBackend.Models.Pallindrome> Pallindrome { get; set; }
    }
}
