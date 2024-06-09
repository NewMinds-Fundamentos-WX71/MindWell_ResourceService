using Microsoft.EntityFrameworkCore;
using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Shared.Extensions;

namespace MindWell_ResourcesServices.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Resource.Domain.Models.Resource> Resources { get; set; }
    public DbSet<UserResource> UserResources { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Resource.Domain.Models.Resource>().ToTable("Resources");
        builder.Entity<Resource.Domain.Models.Resource>().HasKey(p=>p.Id);
        builder.Entity<Resource.Domain.Models.Resource>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Resource.Domain.Models.Resource>().Property(p=>p.Link).IsRequired().HasMaxLength(1000);
        builder.Entity<Resource.Domain.Models.Resource>().Property(p=>p.Category).IsRequired();
        
        builder.Entity<UserResource>().ToTable("UserResources");
        builder.Entity<UserResource>().HasKey(p=>p.Id);
        builder.Entity<UserResource>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<UserResource>().Property(p=>p.User_Id).IsRequired();

        builder.Entity<Resource.Domain.Models.Resource>()
            .HasMany(p => p.UserResources)
            .WithOne(p => p.Resource)
            .HasForeignKey(p => p.Resource_Id);
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}