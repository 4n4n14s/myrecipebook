using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;



namespace MyRecipeBook.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepository(services);
            AddDbContext(services);

        }

        public static void AddDbContext(this IServiceCollection services)
        {
            var connectionString = "Server=localhost;Database=meulivrodereceitas;Uid=root;Password=root;";
            var dbVersion = new MySqlServerVersion (new Version(8, 0, 41));

            services.AddDbContext<MyRecipeBookDbContext>(options =>
            {
                options.UseMySql(connectionString, dbVersion );

            });
        }   

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepositories>();
            services.AddScoped<IUserReadOnlyRepository, UserRepositories>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
