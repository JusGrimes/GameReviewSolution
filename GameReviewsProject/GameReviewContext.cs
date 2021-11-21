using System;
using System.IO;
using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GameReviewSolution;

public class GameReviewContext : DbContext
{
    public GameReviewContext(DbContextOptions<GameReviewContext> options, string dbPath = null) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = dbPath ?? $"{path}{Path.DirectorySeparatorChar}GameReviewDatabase.db";
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ReviewPost> ReviewPosts { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    private string DbPath { get; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}