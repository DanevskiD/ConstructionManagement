using Store.Domain.Interface;
using Store.Domain.Services;
using Store.Persistance.Interfaces;
using Store.Persistance.Storage;

namespace Store.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPackageDocumentService, PackageDocumentService>();


            return services;
        }
    }
}
