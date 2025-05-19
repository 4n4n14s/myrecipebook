using FluentValidation;
using MyRecipeBook.Communcation.Request;
using MyRecipeBook.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    internal class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessegesExceptions.Name_Empty);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessegesExceptions.Email_Empty);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessegesExceptions.Valid_Email);
            RuleFor(User => User.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessegesExceptions.Password_Min_Length);
        }
    }
}
