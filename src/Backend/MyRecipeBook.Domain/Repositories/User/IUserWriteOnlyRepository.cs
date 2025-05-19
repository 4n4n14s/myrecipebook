


namespace MyRecipeBook.Domain.Repositories.User
{
    using MyRecipeBook.Domain.Entities;
    public interface IUserWriteOnlyRepository
    {
        public Task Add(User user);
    }
}
