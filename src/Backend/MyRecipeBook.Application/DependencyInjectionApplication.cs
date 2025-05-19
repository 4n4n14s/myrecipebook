using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Application.UseCases.User.Register;

namespace MyRecipeBook.Application
{
    public static class DependencyInjectionApplication
    {
        public static void AddAplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
            AddPasswordEncrypter(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
           services.AddScoped(opt => new AutoMapper.MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapping());
            }).CreateMapper());

        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services)
        {
            services.AddScoped(opt => new PasswordEncripter());
        }

    }
}
