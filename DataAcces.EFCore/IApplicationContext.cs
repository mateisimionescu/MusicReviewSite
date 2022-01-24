using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore
{
    public interface IApplicationContext
    {
        DbSet<Developer> Developers { get; set; }
        DbSet<Project> Projects { get; set; }

    }
}
