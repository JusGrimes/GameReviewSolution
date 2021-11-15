using System;
using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GameReviewSolution;

public class GameReviewContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ReviewPost> ReviewPosts { get; set; }
    private string DbPath { get; set; }

    public GameReviewContext(DbContextOptions<GameReviewContext> options, string dbPath = null) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = dbPath ?? $"{path}{System.IO.Path.DirectorySeparatorChar}GameReviewDatabase.db";
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}