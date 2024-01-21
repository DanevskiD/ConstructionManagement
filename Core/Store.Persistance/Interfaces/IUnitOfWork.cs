using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Movie> Movies { get; }
        IRepository<User> Users { get; }
        IRepository<Project> Projects { get; }
        IRepository<Document> Documents { get; }

        IRepository<Package> Packages { get; }
        IRepository<PackageDocument> PackageDocuments { get; }

        Task<int> SaveAsync();
    }
}
