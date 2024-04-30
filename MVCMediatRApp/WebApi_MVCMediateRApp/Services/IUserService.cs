using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Services
{
    public interface IUserService {
        Task<List<UserViewModel>> GetAllUsers ();
        Task<UserViewModel> AddUser(CreateUserRequestModel createUserRequestModel);
        Task<UserViewModel> UpdateUser(UpdateUserRequestModel updateUserRequestModel);
        Task<UserViewModel> DeleteUser(int id);
        Task<UserViewModel> GetUserById(int id);
    }
}
