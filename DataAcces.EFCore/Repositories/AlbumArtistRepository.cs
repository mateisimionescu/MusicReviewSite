using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAcces.EFCore.Repositories
{
    public class AlbumArtistRepository : GenericRepository<AlbumArtist>, IAlbumArtistRepository
    {
        public AlbumArtistRepository(ApplicationContext context) : base(context)
        {
        }

        public void removeByAlbumId(int id)
        {
            _context.Remove(_context.AlbumArtists.Where(x => x.AlbumId == id));
            _context.SaveChanges();
        }
    }
}
