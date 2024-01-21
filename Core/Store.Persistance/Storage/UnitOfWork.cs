using Store.Persistance.Context;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;

namespace Store.Persistance.Storage
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(StoreDbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private readonly StoreDbContext databaseContext;

        private bool disposedValue;

        private IRepository<Category> categoriesValue;

        public IRepository<Category> Categories
        {
            get
            {
                if (categoriesValue == null)
                {
                    categoriesValue = new Repository<Category>(databaseContext);
                }

                return categoriesValue;
            }
        }

        private IRepository<Movie> moviesValue;

        public IRepository<Movie> Movies
        {
            get
            {
                if (moviesValue == null)
                {
                    moviesValue = new Repository<Movie>(databaseContext);
                }

                return moviesValue;
            }
        }
        private IRepository<User> usersValue;

        public IRepository<User> Users
        {
            get
            {
                if (usersValue == null)
                {
                    usersValue = new Repository<User>(databaseContext);
                }

                return usersValue;
            }
        }
        private IRepository<Project> projectsValue;

        public IRepository<Project> Projects
        {
            get
            {
                if (projectsValue == null)
                {
                    projectsValue = new Repository<Project>(databaseContext);
                }

                return projectsValue;
            }
        }
        private IRepository<Package> packagesValue;

        public IRepository<Package> Packages
        {
            get
            {
                if (packagesValue == null)
                {
                    packagesValue = new Repository<Package>(databaseContext);
                }
                
                return packagesValue;
            }
        }
        private IRepository<Document> documentsValue;

        public IRepository<Document> Documents
        {
            get
            {
                if (documentsValue == null)
                {
                    documentsValue = new Repository<Document>(databaseContext);
                }

                return documentsValue;
            }
        }
        private IRepository<PackageDocument> packageDocumentsValue;

        public IRepository<PackageDocument> PackageDocuments
        {
            get
            {
                if (packageDocumentsValue == null)
                {
                    packageDocumentsValue = new Repository<PackageDocument>(databaseContext);
                }

                return packageDocumentsValue;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await databaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    databaseContext.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}
