using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data
{
    public class N5DbContext : DbContext
    {
        public virtual DbSet<Permission> Permission { get; set; }

        public virtual DbSet<PermissionType> PermissionType { get; set; }
        public N5DbContext(DbContextOptions<N5DbContext> options)
            : base(options)
        { }

        //public DbSet<Entities.Permission> Permission { get; set; } = default!;

    }
}