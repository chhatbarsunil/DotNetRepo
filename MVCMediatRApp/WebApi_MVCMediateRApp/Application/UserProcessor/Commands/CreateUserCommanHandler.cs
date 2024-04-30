using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_MVCMediateRApp.Services;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Commands
{
    public class CreateUserCommanHandler:IRequestHandler<CreateUserCommand,UserViewModel>
    {
        private readonly IUserService _userService;

        public CreateUserCommanHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserViewModel userViewModel = new();
            var result = await _userService.AddUser(request.createUserRequestModel);
            if (result != null)
            {
                userViewModel = result;
            }
            return userViewModel;
        }
    }
}
