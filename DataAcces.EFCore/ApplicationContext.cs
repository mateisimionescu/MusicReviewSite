using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumArtist>()
                .HasOne(al => al.Album)
                .WithMany(aa => aa.AlbumArtists)
                .HasForeignKey(ali => ali.AlbumId);

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(al => al.Artist)
                .WithMany(aa => aa.AlbumArtists)
                .HasForeignKey(ali => ali.ArtistId);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<AlbumArtist> AlbumArtists { get; set; }
    }
}
