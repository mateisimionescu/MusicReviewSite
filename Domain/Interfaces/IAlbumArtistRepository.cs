using System;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAlbumArtistRepository : IGenericRepository<AlbumArtist>
    {
        void removeByAlbumId(int id);
    }
}
