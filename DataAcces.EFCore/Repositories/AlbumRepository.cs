using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAcces.EFCore.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            var albumList = _context.Albums.ToList<Album>();

            foreach (var album in albumList)
            {
                var AlbumArtistList = _context.AlbumArtists.Where(aa => aa.AlbumId == album.Id);

                foreach (var AlbumArtist in AlbumArtistList)
                {
                    if (album.AlbumArtists.Where(x => x.Id == AlbumArtist.Id) == null){
                        album.AlbumArtists.Add(AlbumArtist);
                    }
                }
            }

            return albumList;
        }

    }
}
