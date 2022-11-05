using Microsoft.EntityFrameworkCore;
using CyberForceWeb.Data.Models;
using IntelliTect.Coalesce;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CoalesceSample.Data.Services;
using System.Security.Claims;

namespace CyberForceWeb.Data;

[Coalesce]
public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<UserDetails> UserDetails => Set<UserDetails>();
    public DbSet<ContactUsForm> ContactUsForms => Set<ContactUsForm>();
    public DbSet<Email> Emails => Set<Email>();
    public DbSet<FileUpload> FileUploads => Set<FileUpload>();
   
    public AppDbContext()
    {
    }

    public IScopedOperationContext OperationContext { get; set; }
    public ClaimsPrincipal? User => OperationContext.User;

    public AppDbContext(IScopedOperationContext operationContext, DbContextOptions<AppDbContext> options) : base(options)
    {
        OperationContext = operationContext;
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    /// <summary>
    /// Migrates the database and sets up items that need to be set up from scratch.
    /// </summary>
    public void Initialize()
    {
        try
        {
            this.Database.Migrate();


            // TODO: Or, use Database.EnsureCreated() instead:
            // this.Database.EnsureCreated();
        }
        catch (InvalidOperationException e) when (e.Message == "No service for type 'Microsoft.EntityFrameworkCore.Migrations.IMigrator' has been registered.")
        {
            // this exception is expected when using an InMemory database
        }
    }
}