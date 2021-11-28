using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GameReviewSolution;

public class GameReviewContext : DbContext
{
    public GameReviewContext(DbContextOptions<GameReviewContext> options, string dbPath = null) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ReviewPost> ReviewPosts { get; set; }
    public DbSet<Publisher> Publishers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }
}