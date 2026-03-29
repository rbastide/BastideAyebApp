using Microsoft.EntityFrameworkCore;
using BastideAyebApp.Models;

namespace BastideAyebApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<CardModels> SavedCards { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}