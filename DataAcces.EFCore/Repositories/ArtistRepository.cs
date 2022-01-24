using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAcces.EFCore.Repositories
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationContext context) : base(context)
        {
        }

        public bool ArtistExists (string artistName)
        {
            if (_context.Artists.Where(ar => ar.Name.Equals(artistName)).FirstOrDefault() == null)
            {
                return false;
            }
            else return true;

        }

        public bool ArtistExists(int artistId)
        {
            if (_context.Artists.Where(ar => ar.Id.Equals(artistId)).FirstOrDefault() == null)
            {
                return true;
            }
            else return false;

        }
    }
}
