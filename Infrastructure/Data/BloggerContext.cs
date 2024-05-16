using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BloggerContext : DbContext
{
    public BloggerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        var entries = ChangeTracker
             .Entries()
             .Where(e => e.Entity is AuditableEnitity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((AuditableEnitity)entityEntry.Entity).LastModified= DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((AuditableEnitity)entityEntry.Entity).Created= DateTime.UtcNow;
            }
        }
        
        return await base.SaveChangesAsync();
    }
}

    

