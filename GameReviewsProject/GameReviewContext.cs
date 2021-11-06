using System;
using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GameReviewSolution
{
    public class GameReviewContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReviewPost> ReviewPosts { get; set;}
        public string DbPath { get; private set; }

        public GameReviewContext(string dbPath = null)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = dbPath ?? $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

    }
}