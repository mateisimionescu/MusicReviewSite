using System;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        bool ArtistExists(string ArtistName);

        bool ArtistExists(int ArtistId);


    }
}
