using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communcation.Request;
using MyRecipeBook.Communcation.Response;

namespace MyRecipeBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public async Task< IActionResult> UserRegister([FromServices]IRegisterUserUseCase useCase ,[FromBody]RequestRegisterUserJson request)
        {
            
            var result = await useCase.Execute(request);
            return Created(string.Empty ,result);
        }
    }
}
