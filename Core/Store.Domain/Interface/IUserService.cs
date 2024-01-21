using Store.Domain.Requests.User;

namespace Store.Domain.Interface
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest request);
    }
}
