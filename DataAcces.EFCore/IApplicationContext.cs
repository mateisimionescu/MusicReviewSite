using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore
{
    public interface IApplicationContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Album> Albums { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<AlbumArtist> AlbumArtists { get; set; }
    }
}
