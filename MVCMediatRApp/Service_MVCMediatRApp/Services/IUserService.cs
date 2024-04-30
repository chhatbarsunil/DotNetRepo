using Core_MVCMediatRApp.ViewModels;

namespace Service_MVCMediatRApp.Services
{
    public interface IUserService {
        Task<List<UserViewModel>> GetAllUsers ();
        Task<UserViewModel> AddUser(CreateUserRequestModel createUserRequestModel);
        Task<UpdateUserRequestModel> UpdateUser(UpdateUserRequestModel updateUserRequestModel);
        Task<UserViewModel> DeleteUser(int id);
        Task<UserViewModel> GetUserById(int id);
        Task<UpdateUserRequestModel> GetUserUpdateById(int id);
    }
}
