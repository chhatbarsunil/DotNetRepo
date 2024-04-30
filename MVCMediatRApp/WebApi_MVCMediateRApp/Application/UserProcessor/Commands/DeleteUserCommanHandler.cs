using MediatR;
using NuGet.Protocol.Plugins;
using WebApi_MVCMediateRApp.Data.Models;
using WebApi_MVCMediateRApp.Services;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Commands
{
    public class DeleteUserCommanHandler:IRequestHandler<DeleteUserCommand, UserViewModel>    {
        private readonly IUserService _userService;

        public DeleteUserCommanHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUser(request.Id);
            return result;
        }
    }
}
