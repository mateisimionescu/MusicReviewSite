using System;
using DataAcces.EFCore.Repositories;
using Domain.Interfaces;

namespace DataAcces.EFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Artists = new ArtistRepository(_context);
            Albums = new AlbumRepository(_context);
            Reviews = new ReviewRepository(_context);
            Users = new UserRepository(_context);
        }

        public IArtistRepository Artists { get; private set; }
        public IAlbumRepository Albums { get; private set; }
        public IReviewRepository Reviews { get; private set; }
        public IUserRepository Users { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
