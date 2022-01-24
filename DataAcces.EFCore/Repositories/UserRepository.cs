using System;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAcces.EFCore.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
