using System;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAcces.EFCore.Repositories
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
