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
    public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,UserViewModel>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUser(request.UpdateUserRequestModel);
            return result;
        }
    }
}
