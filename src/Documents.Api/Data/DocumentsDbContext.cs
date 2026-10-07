using Documents.Api.Models;using Microsoft.EntityFrameworkCore;
namespace Documents.Api.Data;
public sealed class DocumentsDbContext(DbContextOptions<DocumentsDbContext> options):DbContext(options){public DbSet<User> Users=>Set<User>();public DbSet<TrackedDocument> Documents=>Set<TrackedDocument>();public DbSet<DocumentEvent> Events=>Set<DocumentEvent>();protected override void OnModelCreating(ModelBuilder b){b.Entity<User>().HasIndex(x=>x.Username).IsUnique();b.Entity<TrackedDocument>().HasIndex(x=>x.TrackingNumber).IsUnique();}}
