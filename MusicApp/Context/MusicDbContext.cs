using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicApp.Models;
using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Context
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            //Context
            string connectionString = configuration.GetConnectionString("AppDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Album
            modelBuilder.Entity<Album>().HasOne(album => album.Artist).WithOne(artist => artist.Album).HasForeignKey<Album>(album => album.Id);
            modelBuilder.Entity<Album>().HasMany(album => album.Tracks).WithOne(track => track.Album);
            modelBuilder.Entity<Album>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Album>().Property(album => album.DownloadsNumber).HasDefaultValue(0);

            //User
            modelBuilder.Entity<User>().HasMany(user => user.Albums).WithOne(album => album.User);
            modelBuilder.Entity<User>().HasIndex(user => user.Login).IsUnique();
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired(false);
            modelBuilder.Entity<User>().Property(user => user.Surname).IsRequired(false);
            modelBuilder.Entity<User>().Property(user => user.Year).IsRequired(false);
            modelBuilder.Entity<User>().Property(user => user.Email).IsRequired(false);
            modelBuilder.Entity<User>().Property(user => user.IsAdmin).IsRequired(false).HasDefaultValue(true);

            //Init data
            DataInitialize(modelBuilder);
        }

        private void DataInitialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Login = "admin", Password = HasherService.HashPassword("admin") });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
