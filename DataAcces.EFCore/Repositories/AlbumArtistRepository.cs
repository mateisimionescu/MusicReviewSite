using System;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAcces.EFCore.Repositories
{
    public class AlbumArtistRepository : GenericRepository<AlbumArtist>, IAlbumArtistRepository
    {
        public AlbumArtistRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
