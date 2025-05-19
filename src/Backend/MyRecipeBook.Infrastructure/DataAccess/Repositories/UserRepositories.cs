using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories
{
    internal class UserRepositories : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public UserRepositories(MyRecipeBookDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

        public async Task<bool> ExistActiveUser(string email) => await _dbContext.Users.AnyAsync(user => user.Email == email &&  user.Active == true);
        
        
    }
}
