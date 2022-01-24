using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        IEnumerable<Album> GetAllAlbums();
    }

}
