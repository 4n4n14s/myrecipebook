﻿using AutoMapper;
using FluentValidation;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communcation.Request;
using MyRecipeBook.Communcation.Response;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions.ExceptionsBase;


namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {

        private readonly IUserWriteOnlyRepository _WriteOnlyRepository;
        private readonly IUserReadOnlyRepository _ReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserUseCase(
            IUserWriteOnlyRepository writeOnlyRepository, 
            IUserReadOnlyRepository readOnlyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            PasswordEncripter passwordEncripter)
        {
            _WriteOnlyRepository = writeOnlyRepository;
            _ReadOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {

            Validate(request);

            

            var user = _mapper.Map<Domain.Entities.User>(request);

            

            user.Password = _passwordEncripter.Encrypt(request.Password);

             await _WriteOnlyRepository.Add(user);

             await _unitOfWork.Commit();

            return new ResponseRegisterUserJson 
            {
                Name = request.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request) 
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorResult = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorResult);
            }
        }
    }
}
