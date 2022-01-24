using System;
namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        IAlbumRepository Albums { get; }
        IReviewRepository Reviews { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
