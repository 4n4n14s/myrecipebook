using MyRecipeBook.Communcation.Request;
using MyRecipeBook.Communcation.Response;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
