using Microsoft.EntityFrameworkCore;
using WebApi_MVCMediateRApp.Data.MediatRWebApiDbContext;
using WebApi_MVCMediateRApp.Data.Models;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Services
{
    public class UserService : IUserService
    {
        private readonly MediatRWebApiDbContext _dbContext;

        public UserService(MediatRWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserViewModel> AddUser(CreateUserRequestModel createUserRequestModel)
        {
            User user = new User();
            // Map Using AutoMapper;
                user.Id = 0;
                user.UserName = createUserRequestModel.UserName;
                user.Email = createUserRequestModel.Email;
                user.Designation=createUserRequestModel.Designation;
                user.ReportingManager = createUserRequestModel.ReportingManager; ;
                user.Roles = createUserRequestModel.Roles;
                user.Approver = createUserRequestModel.Approver;
                user.DepartmentName= createUserRequestModel.DepartmentName;
                user.IsVendor = createUserRequestModel.IsVendor;
                user.Phone= createUserRequestModel.Phone;
                user.Password= createUserRequestModel.Password;
                
            var result = await _dbContext.Users.AddAsync(user);
             var result2 = await _dbContext.SaveChangesAsync();

            var response = await this.GetUserById(user.Id);

            return response;
        }

        public async Task<UserViewModel> DeleteUser(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            //Check for id and permission 
            if (user != null)
            {
                var result = _dbContext.Users.Remove(user);
                    var result2 = await _dbContext.SaveChangesAsync();
                    //Map using Automapper User to UserViewModel
                    UserViewModel userViewModel = new();
                    userViewModel.Id = user.Id;
                    userViewModel.UserName = user.UserName;
                    userViewModel.Email = user.Email;
                    userViewModel.Designation = user.Designation;
                    userViewModel.ReportingManager = user.ReportingManager; ;
                    userViewModel.Roles = user.Roles;
                    userViewModel.Approver = user.Approver;
                    userViewModel.DepartmentName = user.DepartmentName;
                    userViewModel.IsVendor = user.IsVendor;
                    userViewModel.Phone = user.Phone;
                    return userViewModel;
            }
            else { return new UserViewModel(); }

        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<UserViewModel> users = new();
            users.Add(new UserViewModel());
            
            var result = await _dbContext.Users.ToListAsync();
                if (result != null)
                {
                    users.Clear();
                // user automapper for mapping User to UserModel
                //users = result;

                result.ForEach(user =>
                {
                    UserViewModel userViewModel = new();
                    userViewModel.Id = user.Id;
                    userViewModel.UserName = user.UserName;
                    userViewModel.Email = user.Email;
                    userViewModel.Designation = user.Designation;
                    userViewModel.ReportingManager = user.ReportingManager; ;
                    userViewModel.Roles = user.Roles;
                    userViewModel.Approver = user.Approver;
                    userViewModel.DepartmentName = user.DepartmentName;
                    userViewModel.IsVendor = user.IsVendor;
                    userViewModel.Phone = user.Phone;
                    users.Add(userViewModel);
                });
                }

            return users;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            User user = new();
            // Option 1: Using Where clause and FirstOrDefault
            var result = await _dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            // Option 2: Using Find method (if ID is the primary key)
            // var user = await context.Users.FindAsync(id);
            if(result != null)
            {
                user = result;
            }

            //Map using Automapper User to UserViewModel
                UserViewModel userViewModel = new();
                    userViewModel.Id = user.Id;
                    userViewModel.UserName = user.UserName;
                    userViewModel.Email = user.Email;
                    userViewModel.Designation = user.Designation;
                    userViewModel.ReportingManager = user.ReportingManager; ;
                    userViewModel.Roles = user.Roles;
                    userViewModel.Approver = user.Approver;
                    userViewModel.DepartmentName = user.DepartmentName;
                    userViewModel.IsVendor = user.IsVendor;
                    userViewModel.Phone = user.Phone;
            return userViewModel;
        }

        public async Task<UserViewModel> UpdateUser(UpdateUserRequestModel updateUserRequestModel)
        {
            //User user = new User();
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id== updateUserRequestModel.Id);
            // Map Using AutoMapper;
            if(user!=null)
            {

                user.Id = updateUserRequestModel.Id;
                user.UserName = updateUserRequestModel.UserName;
                user.Email = updateUserRequestModel.Email;
                user.Designation = updateUserRequestModel.Designation;
                user.ReportingManager = updateUserRequestModel.ReportingManager; ;
                user.Roles = updateUserRequestModel.Roles;
                user.Approver = updateUserRequestModel.Approver;
                user.DepartmentName = updateUserRequestModel.DepartmentName;
                user.IsVendor = updateUserRequestModel.IsVendor;
                user.Phone = updateUserRequestModel.Phone;
                user.Password = updateUserRequestModel.Password;

                var result1 = _dbContext.Users.Update(user);
                var result2 = await _dbContext.SaveChangesAsync();
            }
            var response = await this.GetUserById(user.Id);
            return response;
        }
    }
}
