using Microsoft.EntityFrameworkCore;
using SmartTravelAPI.Models;
using System.Collections.Generic;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<SearchHistory> SearchHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cấu hình khoá chính-tự động sinh nếu chưa rõ
        modelBuilder.Entity<Account>().HasKey(a => a.AccountId);
        modelBuilder.Entity<Place>().HasKey(p => p.PlaceId);
        modelBuilder.Entity<Favorite>().HasKey(f => f.FavoriteId);
        modelBuilder.Entity<SearchHistory>().HasKey(s => s.SearchId);

        // Quan hệ
        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Account)
            .WithMany(a => a.Favorites)
            .HasForeignKey(f => f.AccountId);

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Place)
            .WithMany(p => p.Favorites)
            .HasForeignKey(f => f.PlaceId);

        modelBuilder.Entity<SearchHistory>()
            .HasOne(s => s.Account)
            .WithMany(a => a.SearchHistories)
            .HasForeignKey(s => s.AccountId);
    }
}

