namespace Store.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("allowAllHeadersAndMethodsCorsPolicy", policy => policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()));

            return services;
        }
    }
}
