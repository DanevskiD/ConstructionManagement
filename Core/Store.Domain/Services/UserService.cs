using Store.Domain.Interface;
using Store.Domain.Requests.User;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;


namespace Store.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUserAsync(CreateUserRequest request)
        {
            User user = new User(default, Guid.NewGuid(), null, request.Name);

            _unitOfWork.Users.Insert(user);

            await _unitOfWork.SaveAsync();
        }

       
    }
}
