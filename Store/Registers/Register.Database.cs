using Microsoft.EntityFrameworkCore;
using Store.Persistance.Context;

namespace Store.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            services.AddDbContextPool<StoreDbContext>(options =>
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Store;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False", x =>
                {
                }));

            return services;
        }
    }
}
